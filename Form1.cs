using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantarApp
{
	public partial class Form1 : Form
	{
		private readonly object _rxLock = new object();
		private readonly List<byte> _rxBuffer = new List<byte>(4096);

		private const byte STX = 0x02;
		private const byte ETX = 0x03;
		skymineral.KantarWebService webService = null;

		private decimal? _lastSentValue = null;
		private DateTime _lastSentAt = DateTime.MinValue;

		private const decimal _tolerance = 0.01m;
		private CancellationTokenSource _testCts;
		private Task _testTask;
		private static readonly Random _rnd = new Random();
		public Form1()
		{
			InitializeComponent();
		}

		void Init()
		{
			try
			{
				comboPort.Items.Clear();
				comboPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
				textUrl.Text = IniFileCash.Instance.ServerUrl;
				comboPort.Text = IniFileCash.Instance.PortName;
				checkRead.Checked = IniFileCash.Instance.ReadPort;
				checkTest.Checked = IniFileCash.Instance.TestApp;
				if (checkRead.Checked)
				{
					webService = new skymineral.KantarWebService();
					webService.Url = string.Concat(IniFileCash.Instance.ServerUrl, @"CustomPrg/xml/KantarWebService.asmx");

					if (checkTest.Checked)
					{
						StartTestSender();
					}
					else
					{
						serialPort1.PortName = comboPort.Text;
						serialPort1.BaudRate = 9600;
						serialPort1.Parity = System.IO.Ports.Parity.None;
						serialPort1.DataBits = 8;
						serialPort1.StopBits = System.IO.Ports.StopBits.One;
						serialPort1.NewLine = "\r\n";
						serialPort1.ReadTimeout = 2000;
						serialPort1.Encoding = Encoding.ASCII;

						serialPort1.DataReceived += SerialPort1_DataReceived;
						serialPort1.Open();
					}

				}
			}
			catch (Exception e)
			{
				Screens.Error(e);
			}
		}

		private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			try
			{
				int count = serialPort1.BytesToRead;
				if (count <= 0) return;

				byte[] chunk = new byte[count];
				int read = serialPort1.Read(chunk, 0, count);
				if (read <= 0) return;

				lock (_rxLock)
				{
					for (int i = 0; i < read; i++)
						_rxBuffer.Add(chunk[i]);

					ExtractFramesFromBuffer();
				}
			}
			catch (Exception exc)
			{
				Logger.E(exc);
			}
		}

		private void ExtractFramesFromBuffer()
		{
			while (true)
			{
				int stxIndex = _rxBuffer.IndexOf(STX);
				if (stxIndex < 0)
				{
					if (_rxBuffer.Count > 4096)
						_rxBuffer.Clear();
					return;
				}

				if (stxIndex > 0)
					_rxBuffer.RemoveRange(0, stxIndex);

				int etxIndex = IndexOf(_rxBuffer, ETX, 1);
				if (etxIndex < 0)
				{
					return;
				}

				int payloadLen = etxIndex - 1;
				byte[] payloadBytes = _rxBuffer.Skip(1).Take(payloadLen).ToArray();

				_rxBuffer.RemoveRange(0, etxIndex + 1);

				HandlePayload(payloadBytes);

			}
		}

		private void HandlePayload(byte[] payloadBytes)
		{
			try
			{
				string raw = Encoding.ASCII.GetString(payloadBytes);

				string cleaned = raw
					.Replace("\r", "")
					.Replace("\n", "")
					.Trim();

				if (string.IsNullOrWhiteSpace(cleaned))
					return;

				cleaned = cleaned.Replace(',', '.');

				Logger.I(cleaned);

				// Handle format like "!10 000050 000000" - extract numeric value
				decimal dec;
				if (cleaned.StartsWith("!"))
				{
					// Remove '!' prefix and split by spaces
					string withoutPrefix = cleaned.Substring(1).Trim();
					string[] parts = withoutPrefix.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					
					// Typically the weight is in the second part (index 1)
					// Format: "!10 000050 000000" -> parts[0]="10", parts[1]="000050", parts[2]="000000"
					if (parts.Length >= 2)
					{
						// Try to parse the second part as weight
						if (!decimal.TryParse(parts[1],
								NumberStyles.Any,
								CultureInfo.InvariantCulture,
								out dec))
						{
							Logger.W($"STX/ETX payload decimal parse edilemedi. Raw:'{raw}' Clean:'{cleaned}' Part:'{parts[1]}'");
							return;
						}
					}
					else if (parts.Length == 1)
					{
						// Only one part after '!', try to parse it
						if (!decimal.TryParse(parts[0],
								NumberStyles.Any,
								CultureInfo.InvariantCulture,
								out dec))
						{
							Logger.W($"STX/ETX payload decimal parse edilemedi. Raw:'{raw}' Clean:'{cleaned}'");
							return;
						}
					}
					else
					{
						Logger.W($"STX/ETX payload format beklenmiyor. Raw:'{raw}' Clean:'{cleaned}'");
						return;
					}
				}
				else if (!decimal.TryParse(cleaned,
						NumberStyles.Any,
						CultureInfo.InvariantCulture,
						out dec))
				{
					// Try removing all spaces and parsing
					string noSpaces = cleaned.Replace(" ", "");
					if (!decimal.TryParse(noSpaces,
							NumberStyles.Any,
							CultureInfo.InvariantCulture,
							out dec))
					{
						Logger.W($"STX/ETX payload decimal parse edilemedi. Raw:'{raw}' Clean:'{cleaned}'");
						return;
					}
				}

				//Task.Run(() => SendToServer(dec));
				TryQueueSend(dec);
			}
			catch (Exception ex)
			{
				Logger.E(ex);
			}
		}

		private void TryQueueSend(decimal value)
		{
			var now = DateTime.Now;

			if (_lastSentValue == null)
			{
				_lastSentValue = value;
				_lastSentAt = now;
				Task.Run(() => SendToServer(value));
				return;
			}

			if (Math.Abs(_lastSentValue.Value - value) > _tolerance)
			{
				_lastSentValue = value;
				_lastSentAt = now;
				Task.Run(() => SendToServer(value));
				return;
			}

		}

		private void StartTestSender()
		{
			try { _testCts?.Cancel(); } catch { }

			_testCts = new CancellationTokenSource();
			var token = _testCts.Token;

			_testTask = Task.Run(async () =>
			{
				while (!token.IsCancellationRequested)
				{
					decimal val;
					lock (_rnd)
					{
						val = Math.Round((decimal)_rnd.NextDouble() * 1000m, 2);
					}

					TryQueueSend(val);

					try
					{
						await Task.Delay(TimeSpan.FromSeconds(3), token);
					}
					catch { /* cancel */ }
				}
			}, token);
		}

		private void UpdateQtyTextbox(decimal value)
		{
			if (textQty.InvokeRequired)
			{
				textQty.BeginInvoke(new Action(() =>
				{
					textQty.Text = value.ToString("0.00", CultureInfo.InvariantCulture);
				}));
			}
			else
			{
				textQty.Text = value.ToString("0.00", CultureInfo.InvariantCulture);
			}
		}

		private static int IndexOf(List<byte> buffer, byte value, int startIndex)
		{
			for (int i = startIndex; i < buffer.Count; i++)
				if (buffer[i] == value) return i;
			return -1;
		}

		private void ProcessLine(string line)
		{
			try
			{
				line = line.Trim();

				if (!decimal.TryParse(
					line.Replace(',', '.'),
					NumberStyles.Any,
					CultureInfo.InvariantCulture,
					out decimal dec))
				{
					Logger.W($"Decimal parse edilemedi: {line}");
					return;
				}

				Task.Run(() => SendToServer(dec));
			}
			catch (Exception ex)
			{
				Logger.E(ex);
			}
		}

		private void SendToServer(decimal dec)
		{
			try
			{
				UpdateQtyTextbox(dec);
				webService.KantarYaz(dec);

				Logger.I($"Kantar yazıldı: {dec}");
			}
			catch (Exception ex)
			{
				Logger.E(ex);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Init();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			IniFileCash.Instance.PortName = comboPort.Text;
			IniFileCash.Instance.ServerUrl = textUrl.Text;
			IniFileCash.Instance.ReadPort = checkRead.Checked;
			IniFileCash.Instance.TestApp = checkTest.Checked;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (Screens.Question("Uygulama kapanacak onaylıyor musunuz?"))
			{
				if (serialPort1.IsOpen)
				{
					serialPort1.DataReceived -= SerialPort1_DataReceived;
					serialPort1.Close();
				}
				try
				{
					_testCts?.Cancel();
					_testTask?.Wait(500);
				}
				catch { }
				Application.Exit();
				Close();
			}
		}

		private void textQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}

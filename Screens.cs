using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantarApp
{
	public class Screens
	{
		[DebuggerStepThrough()]
		public static void Error(Exception exc, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{

			StringBuilder err = new StringBuilder();
			err.Append(exc.Message).Append(",Detay:").Append(exc.StackTrace);
			Logger.E(err);

			//if (NoSplash) return;
			Cursor.Current = Cursors.Default;
			MessageBox.Show(new StringBuilder().Append(err).AppendLine().AppendFormat("Metod:{0}, Satır:{1}", callerName, lineNumber).ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		[DebuggerStepThrough()]
		public static void Error(string err, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Cursor.Current = Cursors.Default;
			Logger.E(err);

			//if (NoSplash) return;
			MessageBox.Show(new StringBuilder().Append(err).AppendLine().AppendFormat("Metod:{0}, Satır:{1}", callerName, lineNumber).ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		[DebuggerStepThrough()]
		public static void Warning(string warn, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Cursor.Current = Cursors.Default;
			Logger.W(warn);

			//if (NoSplash) return;
			Cursor.Current = Cursors.Default;
			MessageBox.Show(new StringBuilder().Append(warn).AppendLine().AppendFormat("Metod:{0}, Satır:{1}", callerName, lineNumber).ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
		}

		[DebuggerStepThrough()]
		public static void Info(string inf, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Cursor.Current = Cursors.Default;
			Logger.I(inf);

			//if (NoSplash) return;
			Cursor.Current = Cursors.Default;
			MessageBox.Show(new StringBuilder().Append(inf).AppendLine().AppendFormat("Metod:{0}, Satır:{1}", callerName, lineNumber).ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
		}

		[DebuggerStepThrough()]
		public static bool Question(string question, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			//if (NoSplash) return false;
			Cursor.Current = Cursors.Default;
			return MessageBox.Show(new StringBuilder().Append(question).AppendLine().AppendFormat("Metod:{0}, Satır:{1}", callerName, lineNumber).ToString(), "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
		}

		[DllImport("coredll.dll")]
		static extern bool SipShowIM(int dwFlag);

		private const int BS_MULTILINE = 0x00002000;
		private const int GWL_STYLE = -16;

		[DllImport("coredll")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("coredll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		/// <summary>
		/// MakeButtonMultiline(button1);
		/// </summary>
		/// <param name="b"></param>
		public static void MakeButtonMultiline(Button b)
		{
			IntPtr hwnd = b.Handle;
			int currentStyle = GetWindowLong(hwnd, GWL_STYLE);
			int newStyle = SetWindowLong(hwnd, GWL_STYLE, currentStyle | BS_MULTILINE);
		}

		public static void ShowKeyboard(bool open)
		{
			try
			{
				//if (NoSplash) return;

				SipShowIM(open ? 1 : 0);
			}
			catch
			{
				;
			}
		}

		[DllImport("user32.dll")]
		public static extern int FindWindow(
	   string lpClassName, // class name 
	   string lpWindowName // window name 
   );

		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(
			int hWnd // handle to window
			);

	}
}

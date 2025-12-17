using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantarApp
{
	public class Logger
	{
		//const int TraceLevel = 4;

		private static string traceName = string.Empty;

		public static string TraceName => traceName;


		private static string FormatMessage(string level, string message, Exception exception, object obj, string callerName, int lineNumber)
		{
			var builder = new StringBuilder();
			builder.Append($"{level} :: {DateTime.Now}, Caller: {callerName}, Line: {lineNumber}");
			if (!string.IsNullOrEmpty(message))
				builder.Append($", Message: {message}");
			if (exception != null)
				builder.Append($", Exception: {exception.Message}, StackTrace: {exception.StackTrace}");
			builder.AppendFormat(", Object:{0} ", obj != null ? obj.ToString() : "null");
			return builder.ToString();
		}

		private static void Log(string level, string message, Exception exception = null, object obj = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			if (!CanLog(level)) return;

			string formattedMessage = FormatMessage(level, message, exception, obj, callerName, lineNumber);

			Trace.WriteLine(formattedMessage);
			Trace.Flush();
		}

		private static bool CanLog(string level)
		{
			int requiredLevel = 0;
			switch (level)
			{
				case "Error": requiredLevel = 1; break;
				case "Warning": requiredLevel = 2; break;
				case "Info": requiredLevel = 3; break;
				case "Verbose": requiredLevel = 4; break;

			};
			return AppConfig.Default.TraceLevel >= requiredLevel;
		}


		#region Write
		[Conditional("DEBUG")]
		[DebuggerStepThrough()]
		public static void Debug(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Debug", null, exception, null, callerName, lineNumber);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough()]
		public static void Debug(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Debug", str, null, null, callerName, lineNumber);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough()]
		public static void Debug(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Debug", null, null, obj, callerName, lineNumber);
		}

		#endregion

		#region Write
		[DebuggerStepThrough()]
		public static void Write(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			string msg = string.Concat("Trace :: ", DateTime.Now.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber, ", Exception: ", exception.Message, ", StackTrace:", exception.StackTrace);
			Task.Run(() =>
			{
				Trace.WriteLine(msg);
			});
		}

		[DebuggerStepThrough()]
		public static void Write(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			string msg = string.Concat("Trace :: ", DateTime.Now.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber, ", Mesaj: ", str);
			Task.Run(() =>
			{
				Trace.WriteLine(msg);
			});
		}

		[DebuggerStepThrough()]
		public static void Write(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			string msg = string.Concat("Trace :: ", DateTime.Now.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber, ", Object: ", obj != null ? obj.ToString() : "null");
			Task.Run(() =>
			{
				Trace.WriteLine(msg);
			});
		}

		#endregion

		#region Verbose
		[DebuggerStepThrough()]
		public static void V(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Verbose", null, exception, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void V(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Verbose", str, null, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void V(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Verbose", null, null, obj, callerName, lineNumber);
		}
		#endregion

		#region Info
		[DebuggerStepThrough()]
		public static void I(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Info", null, exception, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void I(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Info", str, null, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void I(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Info", null, null, obj, callerName, lineNumber);
		}
		#endregion

		#region Warning
		[DebuggerStepThrough()]
		public static void W(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Warning", null, exception, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void W(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Warning", str, null, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void W(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Warning", null, null, obj, callerName, lineNumber);
		}
		#endregion

		#region Error
		[DebuggerStepThrough()]
		public static void E(Exception exception, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Error", null, exception, null, callerName, lineNumber);

		}

		[DebuggerStepThrough()]
		public static void E(string str, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Error", str, null, null, callerName, lineNumber);
		}

		[DebuggerStepThrough()]
		public static void E(object obj, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
		{
			Log("Error", null, null, obj, callerName, lineNumber);
		}

		#endregion


		public static void AddListener()
		{
			try
			{
				if (System.Diagnostics.Debugger.IsAttached)
				{
				}
				else
				{
					System.Diagnostics.Trace.Listeners.Remove("Default");
				}
				string appName = Assembly.GetCallingAssembly().GetName().Name;

				traceName = $"{Application.StartupPath}\\{appName}.log";

				var fi = new FileInfo(traceName);
				bool append = fi.Exists && fi.Length < 3000000;

				System.IO.StreamWriter writer = new System.IO.StreamWriter(traceName, append, System.Text.Encoding.GetEncoding("windows-1254"));

				System.Diagnostics.TextWriterTraceListener listener = new System.Diagnostics.TextWriterTraceListener(writer);

				System.Diagnostics.Trace.Listeners.Add(listener);

				System.Diagnostics.Trace.AutoFlush = true;

				System.Diagnostics.Trace.WriteLine("-> " + DateTime.Now.ToString() + "\tBaşladı");
			}
			catch
			{
				;
			}
		}
	}
}

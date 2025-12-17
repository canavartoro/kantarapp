using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KantarApp
{
	internal class IniFileCash
	{
		static IniFileCash instance = null;
		string file = "";

		public static IniFileCash Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new IniFileCash(string.Concat(Application.StartupPath, "\\kantarapp.ini"));
				}
				return instance;
			}
		}

		public IniFileCash(string filename)
		{
			file = filename;
		}

		[XmlIgnore()]
		public string PortName
		{
			get
			{
				StringBuilder temp = new StringBuilder(255);
				int i = GetPrivateProfileString("CONFIG", "PORT_NAME", "", temp, 255, file);
				if (i == 0)
				{
					WritePrivateProfileString("CONFIG", "PORT_NAME", "", file);
				}
				return temp.ToString();
			}
			set { WritePrivateProfileString("CONFIG", "PORT_NAME", value, file); }
		}

		[XmlIgnore()]
		public string ServerUrl
		{
			get
			{
				StringBuilder temp = new StringBuilder(255);
				int i = GetPrivateProfileString("CONFIG", "SERVER_URL", "https://skymineral.erp.uyumcloud.com/", temp, 255, file);
				if (i == 0)
				{
					WritePrivateProfileString("CONFIG", "SERVER_URL", "https://skymineral.erp.uyumcloud.com/", file);
				}
				return temp.ToString();
			}
			set { WritePrivateProfileString("CONFIG", "SERVER_URL", value, file); }
		}

		[XmlIgnore()]
		public bool ReadPort
		{
			get
			{
				StringBuilder temp = new StringBuilder(255);
				int i = GetPrivateProfileString("CONFIG", "READ_PORT", "0", temp, 255, file);
				if (i == 0)
				{
					WritePrivateProfileString("CONFIG", "READ_PORT", "0", file);
				}
				return temp.ToString().Equals("1");
			}
			set { WritePrivateProfileString("CONFIG", "READ_PORT", value ? "1" : "0", file); }
		}

		[XmlIgnore()]
		public bool TestApp
		{
			get
			{
				StringBuilder temp = new StringBuilder(255);
				int i = GetPrivateProfileString("CONFIG", "TEST_APP", "0", temp, 255, file);
				if (i == 0)
				{
					WritePrivateProfileString("CONFIG", "TEST_APP", "0", file);
				}
				return temp.ToString().Equals("1");
			}
			set { WritePrivateProfileString("CONFIG", "TEST_APP", value ? "1" : "0", file); }
		}

		[DllImport("kernel32")]
		public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
	}
}

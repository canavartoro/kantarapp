using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace KantarApp
{
	internal class RegistryCash
	{
		private const string REG_SUBKEY = "UYUMSOFT";

		static RegistryCash instance = null;

		public static RegistryCash Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RegistryCash();
				}
				return instance;
			}
		}

		[XmlIgnore()]
		public string PortName
		{
			get { return ReadRegister("PORT_NAME", ""); }
			set { WriteRegister("PORT_NAME", value); }
		}

		[XmlIgnore()]
		public string ServerUrl
		{
			get { return ReadRegister("SERVER_URL", ""); }
			set { WriteRegister("SERVER_URL", value); }
		}

		public int GetIntValue(string key, int defvalue = 0)
		{
			if (int.TryParse(ReadRegister(key, ""), out int index)) return index;
			else return defvalue;
		}

		public void SetIntValue(string key, int value)
		{
			WriteRegister(key, value.ToString());
		}

		public string ReadRegister(string key, string dvalue)
		{
			try
			{
				if (Registry.CurrentUser.OpenSubKey(REG_SUBKEY) == null)
				{
					return dvalue;
				}
				RegistryKey key2 = Registry.CurrentUser.OpenSubKey(REG_SUBKEY);
				string str = key2.GetValue(key, dvalue).ToString();
				key2.Close();
				return str;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public string ReadRegister(string name, string key, string dvalue)
		{
			try
			{
				if (Registry.CurrentUser.OpenSubKey(REG_SUBKEY) == null)
				{
					return null;
				}
				RegistryKey key2 = Registry.CurrentUser.OpenSubKey(REG_SUBKEY);
				RegistryKey key3 = key2.OpenSubKey(name, true);
				if (key3 == null)
				{
					key2.Close();
					return null;
				}
				if (key3.GetValue(key) == null)
				{
					return null;
				}
				string str = key3.GetValue(key).ToString();
				key3.Close();
				key2.Close();
				return str;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool WriteRegister(string key, string svalue)
		{
			try
			{
				if (Registry.CurrentUser.OpenSubKey(REG_SUBKEY, true) == null)
				{
					Registry.CurrentUser.CreateSubKey(REG_SUBKEY);
				}
				Registry.CurrentUser.OpenSubKey(REG_SUBKEY, true).SetValue(key, svalue);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool WriteRegister(string name, string key, string svalue)
		{
			try
			{
				if (Registry.CurrentUser.OpenSubKey(REG_SUBKEY, true) == null)
				{
					Registry.CurrentUser.CreateSubKey(REG_SUBKEY);
				}
				RegistryKey key2 = Registry.CurrentUser.OpenSubKey(REG_SUBKEY, true);
				if (key2.OpenSubKey(name, true) == null)
				{
					key2.CreateSubKey(name);
				}
				key2.OpenSubKey(name, true).SetValue(key, svalue);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}

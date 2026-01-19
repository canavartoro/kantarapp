using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KantarApp
{
	[Serializable()]
	public class AppConfig
	{
		static AppConfig defaultSetting = null;
		public static AppConfig Default
		{
			get
			{
				if (defaultSetting == null)
				{
					defaultSetting = new AppConfig();
				}
				return defaultSetting;
			}
		}

		[System.Xml.Serialization.XmlElement("TraceLevel")]
		public int TraceLevel { get; set; } = 4;

	}
}

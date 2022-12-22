using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WordOFF.Libraries.Project
{
	public enum DateFormat : int
	{
		[Description("Длинный формат: 24 ноября 2022 г.")]
		Long = 0, // D
		[Description("Короткий формат: 24.11.2022")]
		Short = 1 // d
	}
	public class DateFormatReplace
	{
		public bool CustomDate = false;

		[XmlIgnore]
		public CultureInfo Culture = new CultureInfo("ru-RU");

		public DateTime Date;

		public DateFormat DateFormat = DateFormat.Long;
	}
}

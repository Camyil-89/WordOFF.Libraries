using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOFF.Libraries.WOFF
{
	public class InfoAboutWOFFFile
	{
		public string WOFFName { get; set; } = "Project";

		public DateTime DateCreate { get; set; } = DateTime.Now;

		public Guid UIDGroup { get; set; } = Guid.Empty;
	}
}

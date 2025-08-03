using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Pohadja
	{
		public virtual int Id { get; set; }
		public virtual Polaznik Polaznik { get; set; }
		public virtual Kurs Kurs { get; set; }
	}
}

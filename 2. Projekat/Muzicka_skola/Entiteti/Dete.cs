using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Dete
	{
		public virtual int Id { get; set; }
		public virtual DateTime DatumRodjenja { get; set; }
		public virtual string BrojDosijea { get; set; }
		public virtual Staratelj Staratelj { get; set; }
		public virtual Polaznik Polaznik { get; set; }
	}
}

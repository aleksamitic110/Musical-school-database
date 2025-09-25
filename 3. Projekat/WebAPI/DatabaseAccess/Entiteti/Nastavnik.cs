using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Nastavnik
	{
		public virtual int Id { get; set; }
		public virtual Osoba Osoba { get; set; }
		public virtual string StrucnaSprema { get; set; }
		public virtual DateTime DatumZaposlenja { get; set; }

		public virtual IList<Kurs> Kursevi { get; set; } = new List<Kurs>();
		public virtual IList<Komisija> Komisija { get; set; } = new List<Komisija>();
	}
}

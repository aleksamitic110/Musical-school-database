using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Polaznik
	{
		public virtual int Id { get; set; }
		public virtual Osoba Osoba { get; set; }

		public virtual IList<Pohadja> Kursevi { get; set; } = new List<Pohadja>();
		public virtual IList<Evidencija> Prisustva { get; set; } = new List<Evidencija>();
		public virtual IList<Polaganje> Polaganja { get; set; } = new List<Polaganje>();

		public Polaznik() {
			Kursevi = new List<Pohadja>();
			Prisustva = new List<Evidencija>();
			Polaganja = new List<Polaganje>();
		}
	}
}

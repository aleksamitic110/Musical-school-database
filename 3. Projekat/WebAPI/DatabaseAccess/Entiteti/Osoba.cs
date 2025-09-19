using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Osoba
	{
		public virtual string JMBG { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual string Adresa { get; set; }
		public virtual string Mail { get; set; }

		public virtual IList<Telefon> Telefoni { get; set; } = new List<Telefon>();

	}
}

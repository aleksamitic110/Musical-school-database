using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Ispit
	{
		public virtual string Id { get; set; }
		public virtual Kurs Kurs { get; set; }
		public virtual DateTime Datum { get; set; }

		public virtual IList<Komisija> Komisija { get; set; } = new List<Komisija>();
		public virtual IList<Polaganje> Polaganja { get; set; } = new List<Polaganje>();
	}

}

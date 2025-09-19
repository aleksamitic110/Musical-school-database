using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Kurs
	{
		public virtual string Id { get; set; }
		public virtual string Naziv { get; set; }
		public virtual string Nivo { get; set; }
		public virtual string TipNastave { get; set; }
		public virtual Filijala Filijala { get; set; }
		public virtual Nastavnik Nastavnik { get; set; }
		public virtual IList<Cas> Casovi { get; set; } = new List<Cas>();
		public virtual IList<Ispit> Ispiti { get; set; } = new List<Ispit>();
		public virtual IList<Pohadja> Pohadjanja { get; set; } = new List<Pohadja>();
	}


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Filijala
	{
		public virtual string Id { get; set; }
		public virtual string Adresa { get; set; }
		public virtual string RadnoVreme { get; set; }
		public virtual string OpremljenostUcionica { get; set; }
		public virtual int KapacitetFilijale { get; set; }

		public virtual IList<Kurs> Kursevi { get; set; } = new List<Kurs>();
		public virtual IList<Ucionica> Ucionice { get; set; } = new List<Ucionica>();
	}

}

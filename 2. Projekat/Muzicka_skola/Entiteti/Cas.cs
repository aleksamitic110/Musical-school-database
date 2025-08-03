using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Cas
	{
		public virtual string Id { get; set; }
		public virtual DateTime Datum { get; set; }
		public virtual string Vreme { get; set; }
		public virtual string Lekcija { get; set; }
		public virtual Kurs Kurs { get; set; }
		public virtual Ucionica Ucionica { get; set; }

		public virtual IList<Evidencija> Evidencije { get; set; } = new List<Evidencija>();
	}

}

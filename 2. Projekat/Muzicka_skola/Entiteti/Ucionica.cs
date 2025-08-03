using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Ucionica
	{
		public virtual string Id { get; set; }
		public virtual string Oznaka { get; set; }
		public virtual int KapacitetUcionice { get; set; }
		public virtual Filijala Filijala { get; set; }

		public virtual IList<Cas> Casovi { get; set; } = new List<Cas>();
	}
}

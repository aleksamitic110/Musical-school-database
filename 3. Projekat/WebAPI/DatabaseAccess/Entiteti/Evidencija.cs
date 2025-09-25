using Muzicka_skola.Mapiranja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Evidencija
	{
		public virtual int Id { get; set; }
		public virtual int Ocena { get; set; }
		public virtual bool Prisustvo { get; set; }
		public virtual Polaznik Polaznik { get; set; }
		public virtual Cas Cas { get; set; }
	}
}

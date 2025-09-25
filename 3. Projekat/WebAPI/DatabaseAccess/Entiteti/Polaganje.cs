using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Polaganje
	{
		public virtual int Id { get; set; }
		public virtual Polaznik Polaznik { get; set; }
		public virtual Ispit Ispit { get; set; }
		public virtual int Ocena { get; set; }
		public virtual bool Polozio { get; set; }

	}


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Komisija
	{
		public virtual int Id { get; set; }
		public virtual Nastavnik Nastavnik { get; set; }
		public virtual Ispit Ispit { get; set; }
	}
}

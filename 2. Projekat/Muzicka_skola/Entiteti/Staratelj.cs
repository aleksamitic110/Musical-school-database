using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Staratelj
	{
		public virtual int Id { get; set; }
		public virtual Osoba Osoba { get; set; }

		public virtual IList<Dete> Deca { get; set; } = new List<Dete>();
	}
}

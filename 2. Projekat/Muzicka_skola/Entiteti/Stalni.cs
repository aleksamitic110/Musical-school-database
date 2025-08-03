using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Stalni
	{
		public virtual int Id { get; set; }
		public virtual Nastavnik Nastavnik { get; set; }
		public virtual Osoba Mentor { get; set; }
		public virtual string RadnoVreme { get; set; }
		public virtual bool StatusMentora { get; set; }
	}
}

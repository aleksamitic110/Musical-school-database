using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Odrasli
	{
		public virtual int Id { get; set; }
		public virtual Polaznik Polaznik { get; set; }
		public virtual string Zanimanje { get; set; }
	}
}

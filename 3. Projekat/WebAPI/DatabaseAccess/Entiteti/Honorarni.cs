using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
	public class Honorarni
	{
		public virtual int Id { get; set; }
		public virtual Nastavnik Nastavnik { get; set; }
		public virtual string BrojUgovora { get; set; }
		public virtual int BrojCasovaMesecno { get; set; }
		public virtual DateTime TrajanjeUgovora { get; set; }
	}

}

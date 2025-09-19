using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Entiteti
{
    public class KursVokalni : Kurs
    {
		public virtual string TipPevanja { get; set; } // individualno/horsko
	}
}

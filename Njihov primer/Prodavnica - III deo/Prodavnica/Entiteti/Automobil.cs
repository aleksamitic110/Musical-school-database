using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Automobil : Proizvod
    {
        public virtual string NazivSerije { get; set; }
        public virtual string Baterije { get; set; }
    }
}

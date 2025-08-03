using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Lutka : Proizvod
    {
        public virtual string Ime { get; set; }
        public virtual string Govori { get; set; }
        public virtual string OsetljivaDodir { get; set; }
    }
}

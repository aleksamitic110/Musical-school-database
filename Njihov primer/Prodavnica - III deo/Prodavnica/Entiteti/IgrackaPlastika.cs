using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class IgrackaPlastika : Proizvod
    {
        public virtual int Uzrast { get; set; }
        public virtual string Vodootporna { get; set; }
        public virtual string Lomljiva { get; set; }
    }
}

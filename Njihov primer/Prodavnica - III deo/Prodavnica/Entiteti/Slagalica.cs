using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Slagalica : Proizvod
    {
        public virtual int BrojDelova { get; set; }
        public virtual string Turisticka { get; set; }
        public virtual string Umetnicka { get; set; }
        public virtual string Ilustracija { get; set; }
    }
}

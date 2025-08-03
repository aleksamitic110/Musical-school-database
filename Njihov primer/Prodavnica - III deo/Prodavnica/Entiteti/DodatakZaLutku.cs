using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class DodatakZaLutku : Proizvod
    {
        public virtual string NazivDodatka { get; set; }
        public virtual string TipDodatka { get; set; }
    }
}

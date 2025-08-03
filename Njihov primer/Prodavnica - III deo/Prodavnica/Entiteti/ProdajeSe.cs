using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class ProdajeSe
    {
        public virtual int Id { get; set; }
        
        public virtual Proizvod ProdajeProzivod { get; set; }
        public virtual Odeljenje ProdajeOdeljenje { get; set; }
    }
}

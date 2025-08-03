using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Proizvod
    {
        public virtual int BarKod { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Proizvodjac { get; set; }

        public virtual IList<ProdajeSe> ProdajeSeOdeljenja { get; set; }

        public Proizvod()
        {
            ProdajeSeOdeljenja = new List<ProdajeSe>();
        }


    }
}

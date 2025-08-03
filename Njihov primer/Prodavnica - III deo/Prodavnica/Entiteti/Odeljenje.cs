using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public abstract class Odeljenje
    {
        public virtual int Id { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual int BrojKasa { get; set; }
        public virtual string InfoPult { get; set; }

        public virtual Prodavnica PripadaProdavnici { get; set; }

        public virtual IList<ProdajeSe> ProdajeSeProizvod { get; set; }


        public Odeljenje()
        {
            ProdajeSeProizvod = new List<ProdajeSe>();
            
        }
    }

    public class OdeljenjeDo5 : Odeljenje
    {
    }

    public class OdeljenjeOd6Do15 : Odeljenje
    {
    }

    public class OdeljenjeOdrasli : Odeljenje
    {
    }

}

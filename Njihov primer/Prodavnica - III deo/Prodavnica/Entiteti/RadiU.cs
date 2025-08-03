using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class RadiU
    {
       public virtual RadiUId Id {get; set;}
       public virtual DateTime DatumOd { get; set; }
       public virtual DateTime? DatumDo { get; set; }

       public RadiU()
       {
           Id = new RadiUId();
       }

    }
}

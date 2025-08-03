using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class VojnikMapiranja : SubclassMap<Vojnik>
    {
        public VojnikMapiranja()
        {
            Table("VOJNIK");

            KeyColumn("BAR_KOD");
            
            Map(x => x.NazivSerije).Column("NAZIV_SERIJE");
            Map(x => x.Baterije).Column("BATERIJE");
            Map(x => x.Metal).Column("METAL_FLAG");
            Map(x => x.Plastika).Column("PLASTIKA_FLAG");
        }
    }
}

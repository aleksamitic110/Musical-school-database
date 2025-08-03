using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class AutomobilMapiranja : SubclassMap<Automobil>
    {
        public AutomobilMapiranja()
        {
            Table("AUTOMOBIL");

            KeyColumn("BAR_KOD");

            Map(x => x.NazivSerije).Column("NAZIV_SERIJE");
            Map(x => x.Baterije).Column("BATERIJE");
        }
    }
}

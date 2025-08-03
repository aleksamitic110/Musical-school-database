using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class IgrackaPlastikaMapiranja : SubclassMap<IgrackaPlastika>
    {
        public IgrackaPlastikaMapiranja()
        {
            Table("IGRACKE_PLASTIKA");

            KeyColumn("BAR_KOD");

            Map(x => x.Uzrast).Column("UZRAST");
            Map(x => x.Vodootporna).Column("VODOOTPORNA");
            Map(x => x.Lomljiva).Column("LOMLJIVA");
        }
    }
}

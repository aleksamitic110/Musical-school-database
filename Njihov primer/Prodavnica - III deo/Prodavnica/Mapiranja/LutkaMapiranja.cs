using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class LutkaMapiranja : SubclassMap<Lutka>
    {
        public LutkaMapiranja()
        {
            Table("LUTKA");

            KeyColumn("BAR_KOD");

            Map(x => x.Ime).Column("IME");
            Map(x => x.Govori).Column("GOVORI");
            Map(x => x.OsetljivaDodir).Column("OSETLJIVA_DODIR");
        }
    }
}

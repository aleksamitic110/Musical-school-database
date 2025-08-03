using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class SlagalicaMapiranja : SubclassMap<Slagalica>
    {
        public SlagalicaMapiranja()
        {
            Table("PUZZLE");

            KeyColumn("BAR_KOD");

            Map(x => x.BrojDelova).Column("BROJ_DELOVA");
            Map(x => x.Turisticka).Column("TURISTICKA");
            Map(x => x.Umetnicka).Column("UMETNICKA");
            Map(x => x.Ilustracija).Column("ILUSTRACIJA");
        }
    }
}

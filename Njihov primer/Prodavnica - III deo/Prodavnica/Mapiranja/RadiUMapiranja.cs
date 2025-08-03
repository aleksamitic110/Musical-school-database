using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class RadiUMapiranja : ClassMap<RadiU>
    {
        public RadiUMapiranja()
        {
            Table("RADI_U");

            CompositeId(x => x.Id)
                .KeyReference(x => x.RadnikRadiU, "JBR_RADNIK")
                .KeyReference(x => x.RadiUProdavnica, "BROJP");

            Map(x => x.DatumOd).Column("DATUM_OD");
            Map(x => x.DatumDo).Column("DATUM_DO");
        }
    }
}

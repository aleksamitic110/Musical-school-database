using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class DodatakZaLutkuMapiranja : SubclassMap<DodatakZaLutku>
    {
        public DodatakZaLutkuMapiranja()
        {
            Table("DODATAK_ZA_LUTKE");

            KeyColumn("BAR_KOD");

            Map(x => x.NazivDodatka).Column("NAZIV");
            Map(x => x.TipDodatka).Column("TIP");
        }
    }
}

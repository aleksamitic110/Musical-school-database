using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class ProdajeSeMapiranja : ClassMap<ProdajeSe>
    {
        public ProdajeSeMapiranja()
        {
            //Mapiranje tabele
            Table("PRODAJE_SE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16323.PRODAJESE_ID_SEQ");

            //mapiranje veza
            References(x => x.ProdajeProzivod).Column("BAR_KOD");
            References(x => x.ProdajeOdeljenje).Column("ID_ODELJENJE");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class SefujeMapiranja : ClassMap<Sefuje>
    {
        public SefujeMapiranja()
        {
            //Mapiranje tabele
            Table("SEFUJE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16323.SEFUJE_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.DatumPostavljenja, "DATUM_POSTAVLJENJA");

            //mapiranje veza
            References(x => x.Upravnik).Column("JBR_RADNIK");
            References(x => x.Upravlja).Column("BROJP");
        }

    }
}

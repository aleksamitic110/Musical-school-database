using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class RadnikMapiranja : ClassMap<Radnik>
    {
        public RadnikMapiranja()
        {
            Table("RADNIK");

            Id(x => x.Jbr).Column("JBR").GeneratedBy.TriggerIdentity();

            //mapiranje podklasa
            //podrazumevana vrednost je 0
            //svi radnici koji nisu sefovi ce imati vrednost 0 u koloni SEF_FLAG
            DiscriminateSubClassesOnColumn("SEF_FLAG", 0);

            Map(x => x.Mbr).Column("MBR");
            Map(x => x.Ime).Column("LIME");
            Map(x => x.SrednjeSlovo).Column("SSLOVO");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");
            Map(x => x.StrucnaSpema).Column("STRUCNA_SPREMA");
            Map(x => x.Sef).Column("SEF_FLAG");

            HasManyToMany(x => x.Prodavnice)
                .Table("RADI_U")
                .ParentKeyColumn("JBR_RADNIK")
                .ChildKeyColumn("BROJP")
                .Cascade.All();

            HasMany(x => x.RadiUProdavnice).KeyColumn("JBR_RADNIK").LazyLoad().Cascade.All().Inverse();
        }
    }

    public class SefMapiranja : SubclassMap<Sef>
    {
        public SefMapiranja()
        {
            DiscriminatorValue(1);

            HasMany(x => x.SefujeProdavnice).KeyColumn("JBR_RADNIK").LazyLoad().Cascade.All().Inverse();

        }

    }
}

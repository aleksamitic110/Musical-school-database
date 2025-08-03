using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class OdeljenjeMapiranja : ClassMap<Odeljenje>
    {
        public OdeljenjeMapiranja()
        {
            
            //Mapiranje tabele
            Table("ODELJENJE");

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("TIP");

            //mapiranje primarnog kljuca
           // Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity().UnsavedValue(-1);
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            //mapiranje svojstava
            //Map(x => x.Tip, "TIP");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.BrojKasa, "BROJ_KASA");
            Map(x => x.InfoPult, "INFO_PULT");

            //mapiranje veze 1:N Prodavnica-Odeljenje
            References(x => x.PripadaProdavnici).Column("BROJP").LazyLoad();


            HasMany(x => x.ProdajeSeProizvod).KeyColumn("ID_ODELJENJE").LazyLoad().Cascade.All().Inverse();
        }
    }

    class OdeljenjeDo5Mapiranja : SubclassMap<OdeljenjeDo5>
    {
        public OdeljenjeDo5Mapiranja()
        {
            DiscriminatorValue("DO5");
        }
    }

    class OdeljenjeOd6Do15Mapiranja : SubclassMap<OdeljenjeOd6Do15>
    {
        public OdeljenjeOd6Do15Mapiranja()
        {
            DiscriminatorValue("OD6DO15");
        }
    }

    class OdeljenjeOdrasliMapiranja : SubclassMap<OdeljenjeOdrasli>
    {
        public OdeljenjeOdrasliMapiranja()
        {
            DiscriminatorValue("ODRASLI");
        }
    }
}

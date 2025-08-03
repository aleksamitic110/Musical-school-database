using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class ProdavnicaMapiranja : ClassMap<Prodavnica.Entiteti.Prodavnica>
    {
        public ProdavnicaMapiranja()
        {
            //Mapiranje tabele
            Table("PRODAVNICA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "BROJ").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava.
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.BrojTelefona, "BROJ_TELEFONA");
            Map(x => x.RadniDan, "RADNI_DAN");
            Map(x => x.Subota, "SUBOTA");
            Map(x => x.Nedelja, "NEDELJA");

            //mapiranje veze 1:N Prodavnica-Odeljenje
           // HasMany(x => x.Odeljenja).KeyColumn("BROJP");
           // HasMany(x => x.Odeljenja).KeyColumn("BROJP").LazyLoad().Cascade.All();
            HasMany(x => x.Odeljenja).KeyColumn("BROJP").LazyLoad().Cascade.All().Inverse();

            
            HasManyToMany(x => x.Radnici)
                .Table("RADI_U")
                .ParentKeyColumn("BROJP")
                .ChildKeyColumn("JBR_RADNIK")
                .Inverse()
                .Cascade.All();

            HasMany(x => x.RadiURadnici).KeyColumn("BROJP").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.SefujeSefovi).KeyColumn("BROJP").LazyLoad().Cascade.All().Inverse();
             
            
        }
    }
}

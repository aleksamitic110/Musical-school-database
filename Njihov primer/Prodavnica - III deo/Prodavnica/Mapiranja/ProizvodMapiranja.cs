using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;


namespace Prodavnica.Mapiranja
{
    class ProizvodMapiranja : ClassMap<Proizvod>
    {
        public ProizvodMapiranja()
        {
            Table("PROIZVOD");
       

            //Id(x => x.BarKod).Column("BAR_KOD").GeneratedBy.TriggerIdentity();
            //generisanje kljuca uz pomoc sekvence
            Id(x => x.BarKod).Column("BAR_KOD").GeneratedBy.SequenceIdentity("S16323.PROIZVOD_BARKOD_SEQ");

            Map(x => x.Tip).Column("TIP");
            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.Proizvodjac).Column("PROIZVODJAC");

            HasMany(x => x.ProdajeSeOdeljenja).KeyColumn("BAR_KOD").LazyLoad().Cascade.All().Inverse();
        }
    }
}

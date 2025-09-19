using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class NastavnikMap : ClassMap<Nastavnik>
	{
		public NastavnikMap()
		{
			Table("NASTAVNIK");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Osoba).Column("JMBG_OSOBE").Not.Nullable(); 

			Map(x => x.StrucnaSprema).Column("STRUCNASPREMA");
			Map(x => x.DatumZaposlenja).Column("DATUMZAPOSLENJA");

			HasMany(x => x.Kursevi).KeyColumn("NASTAVNIK_ID").Inverse().Cascade.All();
			HasMany(x => x.Komisija).KeyColumn("NASTAVNIK_ID").Inverse().Cascade.All();
		}
	}
}

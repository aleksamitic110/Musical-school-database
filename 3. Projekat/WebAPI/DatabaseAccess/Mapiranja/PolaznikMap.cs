using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class PolaznikMap : ClassMap<Polaznik>
	{
		public PolaznikMap()
		{
			Table("POLAZNIK");  

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Osoba).Column("JMBG_OSOBE").Not.Nullable();

			HasMany(x => x.Kursevi).KeyColumn("POLAZNIK_ID").Inverse().Cascade.All();

			HasMany(x => x.Prisustva).KeyColumn("POLAZNIK_ID").Inverse().Cascade.All();

			HasMany(x => x.Polaganja).KeyColumn("POLAZNIK_ID").Inverse().Cascade.All();
		}
	}
}

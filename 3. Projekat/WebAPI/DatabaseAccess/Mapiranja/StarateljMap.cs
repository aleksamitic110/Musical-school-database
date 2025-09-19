using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class StarateljMap : ClassMap<Staratelj>
	{
		public StarateljMap()
		{
			Table("STARATELJ");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Osoba).Column("JMBG_OSOBE").Not.Nullable(); ;
		}
	}
}

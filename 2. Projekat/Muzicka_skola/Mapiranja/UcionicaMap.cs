using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class UcionicaMap : ClassMap<Ucionica>
	{
		public UcionicaMap()
		{
			Table("UCIONICA");

			Id(x => x.Id, "IDUCIONICE");

			Map(x => x.Oznaka, "OZNAKA");
			Map(x => x.KapacitetUcionice, "KAPACITETUCIONICE");

			References(x => x.Filijala, "IDFILIJALE");

			HasMany(x => x.Casovi).KeyColumn("IDUCIONICE").Inverse().Cascade.All();
		}
	}
}

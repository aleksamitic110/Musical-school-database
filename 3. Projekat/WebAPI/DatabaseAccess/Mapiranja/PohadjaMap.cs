using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class PohadjaMap : ClassMap<Pohadja>
	{
		public PohadjaMap()
		{
			Table("POHADJA");

			Id(x => x.Id, "ID").GeneratedBy.Identity();

			References(x => x.Polaznik, "POLAZNIK_ID");
			References(x => x.Kurs, "IDKURSA");
		}
	}
}

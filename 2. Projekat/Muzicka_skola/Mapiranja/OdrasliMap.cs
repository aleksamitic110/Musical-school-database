using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class OdrasliMap : ClassMap<Odrasli>
	{
		
		public OdrasliMap()
		{
			Table("ODRASLI");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Polaznik).Column("POLAZNIK_ID");

			Map(x => x.Zanimanje).Column("ZANIMANJE");
		}

	}

}

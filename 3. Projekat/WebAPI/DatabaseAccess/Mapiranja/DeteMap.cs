using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class DeteMap : ClassMap<Dete>
	{
		public DeteMap()
		{
			Table("DETE");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Polaznik).Column("POLAZNIK_ID");
			References(x => x.Staratelj).Column("STARATELJ_ID");

			Map(x => x.DatumRodjenja).Column("DATUMRODJENJA");
			Map(x => x.BrojDosijea).Column("BROJDOSIJEA");
		}
	}
}

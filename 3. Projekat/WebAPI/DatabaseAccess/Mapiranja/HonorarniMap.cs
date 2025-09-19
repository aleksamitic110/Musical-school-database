using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class HonorarniMap : ClassMap<Honorarni>
	{
		public HonorarniMap()
		{
			Table("HONORARNI");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Nastavnik).Column("NASTAVNIK_ID");

			Map(x => x.BrojUgovora).Column("BRUGOVORA");
			Map(x => x.BrojCasovaMesecno).Column("BRCASOVAMESECNO");
			Map(x => x.TrajanjeUgovora).Column("TRAJANJEUGOVORA");
		}
	}
}

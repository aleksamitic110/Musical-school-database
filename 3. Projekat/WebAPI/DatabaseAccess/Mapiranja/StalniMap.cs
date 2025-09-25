using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class StalniMap : ClassMap<Stalni>
	{
		public StalniMap()
		{
			Table("STALNI");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			References(x => x.Nastavnik).Column("NASTAVNIK_ID");
			References(x => x.Mentor).Column("JMBGMENTORA");

			Map(x => x.RadnoVreme).Column("RADNOVREME");
			Map(x => x.StatusMentora).Column("STATUSMENTORA");
		}
	}
}

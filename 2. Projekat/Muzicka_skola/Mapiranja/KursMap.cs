using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class KursMap : ClassMap<Kurs>
	{
		public KursMap()
		{
			Table("KURS");

			Id(x => x.Id, "IDKURSA");

			Map(x => x.Naziv, "NAZIV");
			Map(x => x.Nivo, "NIVO");
			Map(x => x.TipNastave, "TIPNASTAVE");

			References(x => x.Filijala, "IDFILIJALE");
			References(x => x.Nastavnik, "NASTAVNIK_ID");

			HasMany(x => x.Casovi).KeyColumn("IDKURSA").Inverse().Cascade.All();

			HasMany(x => x.Ispiti).KeyColumn("IDKURSA").Inverse().Cascade.All();

			HasMany(x => x.Pohadjanja).KeyColumn("IDKURSA").Inverse().Cascade.All();
		}
	}
}

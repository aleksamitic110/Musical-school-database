using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class FilijalaMap : ClassMap<Filijala>
	{
		public FilijalaMap()
		{
			Table("FILIJALA");

			Id(x => x.Id, "IDFILIJALE");

			Map(x => x.Adresa, "ADRESA");
			Map(x => x.RadnoVreme, "RADNOVREME");
			Map(x => x.OpremljenostUcionica, "OPREMLJENOSTUCIONICA");
			Map(x => x.KapacitetFilijale, "KAPACITETFILIJALE");

			HasMany(x => x.Ucionice).KeyColumn("IDFILIJALE").Inverse().Cascade.All();

			HasMany(x => x.Kursevi).KeyColumn("IDFILIJALE").Inverse().Cascade.All();
		}
	}
}

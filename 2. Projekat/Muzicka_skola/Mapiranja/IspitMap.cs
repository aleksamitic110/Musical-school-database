using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class IspitMap : ClassMap<Ispit>
	{
		public IspitMap()
		{
			Table("ISPIT");

			Id(x => x.Id, "IDISPITA");

			Map(x => x.Datum, "DATUM");

			References(x => x.Kurs, "IDKURSA");

			HasMany(x => x.Komisija).KeyColumn("IDISPITA").Inverse().Cascade.All();

			HasMany(x => x.Polaganja).KeyColumn("IDISPITA").Inverse().Cascade.All();
		}
	}
}

using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class KomisijaMap : ClassMap<Komisija>
	{
		public KomisijaMap()
		{
			Table("KOMISIJA");

			Id(x => x.Id, "ID");

			References(x => x.Ispit, "IDISPITA");
			References(x => x.Nastavnik, "NASTAVNIK_ID");
		}
	}
}

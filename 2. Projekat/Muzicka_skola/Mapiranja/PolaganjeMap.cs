using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class PolaganjeMap : ClassMap<Polaganje>
	{
		public PolaganjeMap()
		{
			Table("POLAGANJE");

			Id(x => x.Id, "ID");

			References(x => x.Polaznik, "POLAZNIK_ID");
			References(x => x.Ispit, "IDISPITA");

			Map(x => x.Ocena, "OCENA");
			Map(x => x.Polozio, "POLOZIO");
		}
	}
}

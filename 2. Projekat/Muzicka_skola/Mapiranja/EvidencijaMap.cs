using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class EvidencijaMap : ClassMap<Evidencija>
	{
		public EvidencijaMap()
		{
			Table("EVIDENCIJA");

			Id(x => x.Id, "ID");

			References(x => x.Polaznik, "POLAZNIK_ID");
			References(x => x.Cas, "IDCASA");

			Map(x => x.Ocena, "OCENA");
			Map(x => x.Prisustvo, "PRISUSTVO");
		}
	}
}

using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class KursTeorijskiMap : SubclassMap<KursTeorijski>
	{
		public KursTeorijskiMap()
		{
			Table("KURSTEORIJSKI");

			KeyColumn("IDKURSA");

			Map(x => x.NazivPredmeta, "NAZIVPREDMETA");
		}
	}
}

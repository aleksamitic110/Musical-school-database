using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class KursInstrumentalniMap : SubclassMap<KursInstrumentalni>
	{
		public KursInstrumentalniMap()
		{
			Table("KURSINSTRUMENTALNI");

			KeyColumn("IDKURSA"); 

			Map(x => x.Instrumenti, "INSTRUMENTI");
		}
	}
}

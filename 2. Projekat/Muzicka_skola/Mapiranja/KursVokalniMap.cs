using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class KursVokalniMap : SubclassMap<KursVokalni>
	{
		public KursVokalniMap()
		{
			Table("KURSVOKALNI"); 

			KeyColumn("IDKURSA"); 

			Map(x => x.TipPevanja, "TIPPEVANJA");
		}
	}
}

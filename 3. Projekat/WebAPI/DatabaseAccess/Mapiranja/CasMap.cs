using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class CasMap : ClassMap<Cas>
	{
		public CasMap()
		{
			Table("CAS");

			Id(x => x.Id, "IDCASA");

			Map(x => x.Datum, "DATUM");
			Map(x => x.Vreme, "VREME");
			Map(x => x.Lekcija, "LEKCIJA");

			References(x => x.Kurs, "IDKURSA");
			References(x => x.Ucionica, "IDUCIONICE");

			HasMany(x => x.Evidencije).KeyColumn("IDCASA").Inverse().Cascade.All();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;

namespace Muzicka_skola.Mapiranja
{
	public class TelefonMap : ClassMap<Telefon>
	{
		public TelefonMap()
		{
			Table("TELEFON");

			Id(x => x.Id).Column("ID").GeneratedBy.Identity();
			Map(x => x.BrojTelefona).Column("BROJTELEFONA");

			References(x => x.Osoba).Column("JMBG");
		}
	}
}

using FluentNHibernate.Mapping;
using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola.Mapiranja
{
	public class OsobaMap : ClassMap<Osoba>
	{
		public OsobaMap()
		{
			Table("OSOBA");

			Id(x => x.JMBG).Column("JMBG").GeneratedBy.Assigned();

			Map(x => x.Ime).Column("IME");
			Map(x => x.Prezime).Column("PREZIME");
			Map(x => x.Adresa).Column("ADRESA");
			Map(x => x.Mail).Column("MAIL");

			HasMany(x => x.Telefoni).KeyColumn("JMBG").Inverse().Cascade.All();
		}
	}
}

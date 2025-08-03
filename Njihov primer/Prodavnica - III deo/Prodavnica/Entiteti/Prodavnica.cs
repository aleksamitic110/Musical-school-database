using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Prodavnica.Entiteti
{
    public class Prodavnica
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrojTelefona { get; set; }
        public virtual string RadniDan { get; set; }
        public virtual string Subota { get; set; }
        public virtual string Nedelja { get; set; }

        public virtual IList<Odeljenje> Odeljenja { get; set; }

        public virtual IList<Radnik> Radnici { get; set; }

        public virtual IList<RadiU> RadiURadnici { get; set; }

        public virtual IList<Sefuje> SefujeSefovi { get; set; }

        public Prodavnica()
        {
            Odeljenja = new List<Odeljenje>();

            Radnici = new List<Radnik>();

            RadiURadnici = new List<RadiU>();

            SefujeSefovi = new List<Sefuje>();
        }
    }
}

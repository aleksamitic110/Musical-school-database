using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Radnik
    {
        public virtual int Jbr { get; set; }
        public virtual int Mbr { get; set; }
        public virtual string Ime { get; set; }
        public virtual char SrednjeSlovo { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string StrucnaSpema { get; set; }
        public virtual bool Sef { get; protected set; }

        public virtual IList<Prodavnica> Prodavnice { get; set; }

        public virtual IList<RadiU> RadiUProdavnice { get; set; }

        public Radnik()
        {

            Prodavnice = new List<Prodavnica>();

            RadiUProdavnice = new List<RadiU>();
        }
    }

    public class Sef : Radnik
    {
        public virtual IList<Sefuje> SefujeProdavnice {get; set;}

        public Sef()
        {
            SefujeProdavnice = new List<Sefuje>();
        }

    }
}

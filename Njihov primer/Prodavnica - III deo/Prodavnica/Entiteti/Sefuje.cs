using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class Sefuje
    {
        public virtual int Id { get; set; }
        public virtual DateTime DatumPostavljenja { get; set; }

        public virtual Sef Upravnik { get; set; }
        public virtual Prodavnica Upravlja { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica.Entiteti
{
    public class RadiUId
    {
        public virtual Radnik RadnikRadiU { get; set; }
        public virtual Prodavnica RadiUProdavnica { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(RadiUId))
                return false;

            RadiUId recievedObject = (RadiUId)obj;

            if ((RadnikRadiU.Jbr == recievedObject.RadnikRadiU.Jbr) &&
                (RadiUProdavnica.Id == recievedObject.RadiUProdavnica.Id))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

using System;
using System.Collections.ObjectModel;

namespace Gigi.Domain
{
    public class Garment
    {
        public Int32 GarmentId { get; set; }
        public String Description { get; set; }
        public Int32 GarmentTypeId { get; set; }
        public virtual GarmentType GarmentType { get; set; }
        public virtual Collection<GarmentToGarmentSize> GarmentToGarmentSizes { get; set; }
    }
}

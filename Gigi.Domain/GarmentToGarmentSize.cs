using System;

namespace Gigi.Domain
{
    public class GarmentToGarmentSize
    {
        public Int32 GarmentToGarmentSizeId { get; set; }
        public Int32 GarmentId { get; set; }
        public Int32 GarmentSizeId { get; set; }
        public virtual GarmentSize GarmentSize { get; set; }
    }
}

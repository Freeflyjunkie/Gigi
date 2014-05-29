using System;

namespace Gigi.Domain
{
    public class OrderToGarment
    {
        public Int32 OrderToGarmentId { get; set; }
        public Int32 OrderId { get; set; }
        public Int32 GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
    }
}

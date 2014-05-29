using System;

namespace Gigi.Domain
{
    public class WishlistToGarment
    {
        public Int32 WishlistToGarmentId { get; set; }
        public Int32 WishlistId { get; set; }
        public Int32 GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
    }
}

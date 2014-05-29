using System;
using System.Collections.ObjectModel;

namespace Gigi.Domain
{
    public class Wishlist
    {
        public Int32 WishlistId { get; set; }
        public Int32 CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Collection<WishlistToGarment> WishlistToGarments { get; set; }
    }
}

using System;
using System.Collections.ObjectModel;

namespace Gigi.Domain
{
    public class Order
    {
        public Int32 OrderId { get; set; }
        public Int32 CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Collection<OrderToGarment> OrderToGarments  { get; set; }
    }
}

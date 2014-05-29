using System;

namespace Gigi.Domain
{
    public class CustomerAddress
    {
        public Int32 CustomerAddressId { get; set; }
        public Int32 CustomerId { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
    }
}

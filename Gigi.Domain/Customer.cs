using System;

namespace Gigi.Domain
{
    public class Customer
    {
        public Int32 CustomerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual CustomerCreditCard CustomerCreditCard { get; set; }
    }
}

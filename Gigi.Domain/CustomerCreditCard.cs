using System;

namespace Gigi.Domain
{
    public class CustomerCreditCard
    {
        public Int32 CustomerCreditCardId { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Int32 SecurityCode { get; set; }
    }
}

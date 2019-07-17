using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            TblOrder = new HashSet<Order>();
        }

        public int IdPaymentMethod { get; set; }
        public int IdCustomer { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public int SecurityCode { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual ICollection<Order> TblOrder { get; set; }
    }
}

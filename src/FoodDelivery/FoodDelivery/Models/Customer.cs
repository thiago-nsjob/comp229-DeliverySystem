using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TblDeliveryAddress = new HashSet<DeliveryAddress>();
            TblOrder = new HashSet<Order>();
            TblPaymentMethod = new HashSet<PaymentMethod>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }

        public virtual ICollection<DeliveryAddress> TblDeliveryAddress { get; set; }
        public virtual ICollection<Order> TblOrder { get; set; }
        public virtual ICollection<PaymentMethod> TblPaymentMethod { get; set; }
    }
}

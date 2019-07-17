using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class DeliveryAddress
    {
        public DeliveryAddress()
        {
            TblOrder = new HashSet<Order>();
        }

        public int IdAddress { get; set; }
        public int IdCustomer { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual ICollection<Order> TblOrder { get; set; }
    }
}

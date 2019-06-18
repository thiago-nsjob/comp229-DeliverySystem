﻿using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            TblOrder = new HashSet<Order>();
        }

        public int IdOrderStatus { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Order> TblOrder { get; set; }
    }
}

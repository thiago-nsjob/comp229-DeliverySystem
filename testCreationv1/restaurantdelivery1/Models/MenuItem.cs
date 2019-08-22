﻿using System;
using System.Collections.Generic;

namespace restaurantdelivery1.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            Order = new HashSet<Order>();
        }

        public int IdMenuItem { get; set; }
        public int IdRestaurant { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }

        public virtual Restaurant IdRestaurantNavigation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}

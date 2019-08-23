using System;
using System.Collections.Generic;

namespace restaurantdelivery1.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            MenuItem = new HashSet<MenuItem>();
            Order = new HashSet<Order>();
        }

        public int IdRestaurant { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RestaurantDelivery.Models
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            MenuItems = new HashSet<MenuItems>();
            Orders = new HashSet<Orders>();
        }

        public int IdRestaurant { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<MenuItems> MenuItems { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

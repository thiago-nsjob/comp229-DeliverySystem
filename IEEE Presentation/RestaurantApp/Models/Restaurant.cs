using System;
using System.Collections.Generic;

namespace RestaurantApp.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantMenu = new HashSet<RestaurantMenu>();
        }

        public int IdRestaurant { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<RestaurantMenu> RestaurantMenu { get; set; }
    }
}

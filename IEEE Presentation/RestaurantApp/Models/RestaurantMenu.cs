using System;
using System.Collections.Generic;

namespace RestaurantApp.Models
{
    public partial class RestaurantMenu
    {
        public RestaurantMenu()
        {
            RestaurantMenuItem = new HashSet<RestaurantMenuItem>();
        }

        public int IdRestaurantMenu { get; set; }
        public int IdRestaurant { get; set; }
        public string MenuName { get; set; }
        public string MenuType { get; set; }

        public virtual Restaurant IdRestaurantNavigation { get; set; }
        public virtual ICollection<RestaurantMenuItem> RestaurantMenuItem { get; set; }
    }
}

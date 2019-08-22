using System;
using System.Collections.Generic;

namespace RestaurantDelivery.Models
{
    public partial class MenuItems
    {
        public MenuItems()
        {
            Orders = new HashSet<Orders>();
        }

        public int IdMenuItem { get; set; }
        public int IdRestaurant { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }

        public virtual Restaurants IdRestaurantNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

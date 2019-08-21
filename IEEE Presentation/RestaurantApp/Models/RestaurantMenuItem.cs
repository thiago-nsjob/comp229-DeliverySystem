using System;
using System.Collections.Generic;

namespace RestaurantApp.Models
{
    public partial class RestaurantMenuItem
    {
        public int IdRestaurantMenuItem { get; set; }
        public int IdRestaurantMenu { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual RestaurantMenu IdRestaurantMenuNavigation { get; set; }
    }
}

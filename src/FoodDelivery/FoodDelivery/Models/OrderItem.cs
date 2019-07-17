using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class OrderItem
    {
        public int IdOrderItem { get; set; }
        public int IdOrder { get; set; }
        public int IdRestaurantMenuItem { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnity { get; set; }

        public virtual Order OrderNavigation { get; set; }

        public RestaurantMenuItem RestaurantMenuItemNavigation { get; set; }
    }
}

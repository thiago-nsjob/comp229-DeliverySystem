using System;
using System.Collections.Generic;

namespace RestaurantDelivery.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int IdRestaurant { get; set; }
        public int IdMenuItem { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal? OrderNetAmount { get; set; }
        public decimal? OrderTax { get; set; }
        public decimal? OrderGrossAmount { get; set; }
        public string CustomerNotes { get; set; }

        public virtual MenuItems IdMenuItemNavigation { get; set; }
        public virtual Restaurants IdRestaurantNavigation { get; set; }
    }
}

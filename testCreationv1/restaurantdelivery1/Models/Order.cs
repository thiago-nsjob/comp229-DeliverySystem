using System;
using System.Collections.Generic;

namespace restaurantdelivery1.Models
{
    public partial class Order
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

        public virtual MenuItem IdMenuItemNavigation { get; set; }
        public virtual Restaurant IdRestaurantNavigation { get; set; }
    }
}

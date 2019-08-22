using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDelivery.Models
{
    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        public int IdRestaurant { get; set; }
        public int IdMenuItem { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal? OrderNetAmount { get; set; }
        public decimal? OrderTax { get; set; }
        public decimal? OrderGrossAmount { get; set; }
        public string CustomerNotes { get; set; }

        public virtual MenuItem MenuItemNavigation { get; set; }
        public virtual Restaurant RestaurantNavigation { get; set; }
    }
}

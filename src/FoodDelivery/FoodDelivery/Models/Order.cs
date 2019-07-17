using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public partial class Order
    {
        public Order()
        {
            TblOrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdAddress { get; set; }
        public int IdPaymentMethod { get; set; }
        public int IdRestaurant { get; set; }
        public int IdOrderStatus { get; set; }
        public decimal OrderNetAmount { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderGrossAmount { get; set; }
        public string CustomerNotes { get; set; }

        public virtual DeliveryAddress AddressNavigation { get; set; }
        public virtual Customer CustomerNavigation { get; set; }
        public virtual OrderStatus OrderStatusNavigation { get; set; }
        public virtual PaymentMethod PaymentMethodNavigation { get; set; }
        public virtual Restaurant RestaurantNavigation { get; set; }
        public virtual ICollection<OrderItem> TblOrderItem { get; set; }
    }
}

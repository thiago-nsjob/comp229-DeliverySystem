using System;
using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public partial class Order
    {
        public Order()
        {
            TblOrderItem = new HashSet<OrderItem>();
        }

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

        public virtual DeliveryAddress IdAddressNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual OrderStatus IdOrderStatusNavigation { get; set; }
        public virtual PaymentMethod IdPaymentMethodNavigation { get; set; }
        public virtual Restaurant IdRestaurantNavigation { get; set; }
        public virtual ICollection<OrderItem> TblOrderItem { get; set; }
    }
}

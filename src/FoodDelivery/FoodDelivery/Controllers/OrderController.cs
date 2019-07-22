using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _Order;
        private readonly IRepository<Customer> _Customer;
        private readonly IRepository<DeliveryAddress> _DeliveryAddress;
        private readonly IRepository<Restaurant> _Restaurant;
        private readonly IRepository<PaymentMethod> _PaymentMethod;
        private readonly IRepository<OrderStatus> _OrderStatus;
      
        public OrderController(IRepository<Order> _IOrder, 
                               IRepository<Customer> _ICustomer,
                               IRepository<DeliveryAddress> _IDeliveryAddress,
                               IRepository<Restaurant> _IRestaurant,
                               IRepository<PaymentMethod> _IPaymentMethod,
                               IRepository<OrderStatus> _IOrderStatus)
        {
            _Order = _IOrder;
            _Customer = _ICustomer;
            _DeliveryAddress = _IDeliveryAddress;
            _Restaurant = _IRestaurant;
            _PaymentMethod = _IPaymentMethod;
            _OrderStatus = _IOrderStatus;
        }

        // GET: Delivery Order
        public IActionResult Index()
        {
            return View(_Order.GetAll);
        }

        //GET: DeliveryAddress/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _Order.GetById(id);

            if (order == null)
                return NotFound();


            return View(order);
        }

        // GET: DeliveryAddress/Create
        public IActionResult Create()
        {
            ViewBag.CustomerNavigation = _Customer.GetAll;
            ViewBag.AddressNavigation = _DeliveryAddress.GetAll;
            ViewBag.RestaurantNavigation = _Restaurant.GetAll;
            ViewBag.PaymentMethodNavigation = _PaymentMethod.GetAll;
            ViewBag.OrderStatusNavigation = _OrderStatus.GetAll;
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdOrder,IdCustomer,IdAddress,IdPaymentMethod,IdRestaurant," +
                                        "IdOrderStatus,OrderNetAmount,OrderTax," +
                                        "OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (ModelState.IsValid)
            {
                _Order.Add(order);

                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _Order.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

           
            return View(order);
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdOrder,IdCustomer,IdAddress,IdPaymentMethod,IdRestaurant," +
                                        "IdOrderStatus,OrderNetAmount,OrderTax," +
                                        "OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (id != order.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Order.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.IdOrder))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var order = _Order.GetById(id);

            if (_Order.GetById(id) == null)
                return NotFound();

            return View(order);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _Order.GetById(id);
            _Order.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _Order.GetById(id) != null;
        }

    }
}
using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _repository;

        public OrderController(IRepository<Order> repository)
        {
            _repository = repository;
        }

        // GET: Delivery Order
        public IActionResult Index()
        {
            return View(_repository.GetAll);
        }

        //GET: DeliveryAddress/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _repository.GetById(id);

            if (order == null)
                return NotFound();


            return View(order);
        }

        // GET: DeliveryAddress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdOrder,IdCustomer,IdAddress,IdPaymentMethod,IdRestaurant,IdOrderStatus,OrderNetAmount,OrderTax,OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(order);

                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }



    }
}
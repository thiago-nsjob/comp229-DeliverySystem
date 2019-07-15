using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class DeliveryAddressController : Controller
    {
        private readonly IRepository<DeliveryAddress> _repository;

        public DeliveryAddressController(IRepository<DeliveryAddress> repository)
        {
            _repository = repository;
        }

        // GET: Delivery Address
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

            var deliveryAddress = _repository.GetById(id);

            if (deliveryAddress == null)
                return NotFound();


            return View(deliveryAddress);
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
        public IActionResult Create([Bind("IdAddress,IdCustomer,Street,City,Number")] DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(deliveryAddress);
                
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryAddress);
        }




    }
}
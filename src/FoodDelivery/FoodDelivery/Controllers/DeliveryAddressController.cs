using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Controllers
{
    public class DeliveryAddressController : Controller
    {
        private readonly IRepository<DeliveryAddress> _DeliveryAddress;
        private readonly IRepository<Customer> _Customer;

        public DeliveryAddressController(IRepository<DeliveryAddress> _IDeliveryAddress, IRepository<Customer> _ICustomer)
        {
            _DeliveryAddress = _IDeliveryAddress;
            _Customer = _ICustomer;
        }

        // GET: Delivery Address
        public IActionResult Index()
        {
            return View(_DeliveryAddress.GetAll);
        }

        //GET: DeliveryAddress/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAddress = _DeliveryAddress.GetById(id);

            if (deliveryAddress == null)
                return NotFound();


            return View(deliveryAddress);
        }

        // GET: DeliveryAddress/Create
        public IActionResult Create()
        {
            ViewBag.CustomerNavigation = _Customer.GetAll;
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
                _DeliveryAddress.Add(deliveryAddress);
                
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryAddress);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAddress = _DeliveryAddress.GetById(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            ViewBag.CustomerNavigation = _Customer.GetAll;
            return View(deliveryAddress);
        }

       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdAddress,IdCustomer,Street,City,Number")] DeliveryAddress deliveryAddress)
        {
            if (id != deliveryAddress.IdAddress)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _DeliveryAddress.Update(deliveryAddress);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryAddressExists(deliveryAddress.IdCustomer))
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
            return View(deliveryAddress);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = _DeliveryAddress.GetById(id);

            if (_DeliveryAddress.GetById(id) == null)
                return NotFound();



            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _DeliveryAddress.GetById(id);
            _DeliveryAddress.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        private bool DeliveryAddressExists(int id)
        {
            return _DeliveryAddress.GetById(id) != null;
        }


    }
}
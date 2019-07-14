using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private FoodDeliveryContext _context;
        public CustomerRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll =>
            _context.Customer
            .Include(c => c.TblDeliveryAddress)
            .Include(c => c.TblPaymentMethod);

        public void Add(Customer entity)
        {
            _context.Customer.Add(entity);
            _context.SaveChanges();
        }

        public Customer GetById(int? Id)
        {
            return _context.Customer
                .SingleOrDefault(item => item.IdCustomer == Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}

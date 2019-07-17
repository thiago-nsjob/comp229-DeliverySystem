using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class PaymentMethodRepository : IRepository<PaymentMethod>
    {
        private FoodDeliveryContext _context;
        public PaymentMethodRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentMethod> GetAll => _context.PaymentMethod
            .Include(pay => pay.CustomerNavigation)
            .Include(pay => pay.TblOrder);

        public void Add(PaymentMethod entity)
        {
            _context.PaymentMethod.Add(entity);
            _context.SaveChanges();
        }

        public PaymentMethod GetById(int? Id)
        {
            return _context.PaymentMethod
                  .SingleOrDefault(item => item.IdPaymentMethod == Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.PaymentMethod.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(PaymentMethod entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}

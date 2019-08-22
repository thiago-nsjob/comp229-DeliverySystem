using RestaurantDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDelivery.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        RestaurantDeliveryContext _repository;

        public OrderRepository(RestaurantDeliveryContext repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Order>> GetAll() =>
            await Task.FromResult(_repository.Order
                //.Include(res => res.MenuItem)
                //.ThenInclude(menu => menu.RestaurantMenuItem) //Intellisense issue https://github.com/dotnet/roslyn/issues/8237
                );

        public async Task<Order> Add(Order entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public Order GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}

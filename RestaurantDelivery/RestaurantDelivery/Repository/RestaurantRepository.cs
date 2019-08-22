using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDelivery.Repository
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        RestaurantDeliveryContext _repository;

        public RestaurantRepository(RestaurantDeliveryContext repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Restaurant>> GetAll() =>
            await Task.FromResult(_repository.Restaurant
                .Include(res => res.MenuItem)
                    //.ThenInclude(menu => menu.RestaurantMenuItem) //Intellisense issue https://github.com/dotnet/roslyn/issues/8237
                );

        public async Task<Restaurant> Add(Restaurant entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public Restaurant GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using restaurantdelivery1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantdelivery1.Repository
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        RestaurantContext _repository;

        public RestaurantRepository(RestaurantContext repository)
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
            _repository.SaveChanges();
            return entity;
        }

        public async Task<Restaurant> GetById(int? Id)
        {
            return await _repository.Restaurant
                  .SingleOrDefaultAsync(item => item.IdRestaurant == Id.Value);
        }

        public async Task Remove(int? Id)
        {
            var customer = await GetById(Id);
            _repository.Restaurant.Remove(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(Restaurant entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
        /*
        public Task SaveChangesAsync()
        {
            return Task.Run(() => {
                _repository.SaveChanges();
            });
        }*/
    }
}

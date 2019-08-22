using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDelivery.Repository
{
    public class MenuItemRepository : IRepository<MenuItem>
    {
        RestaurantDeliveryContext _repository;

        public MenuItemRepository(RestaurantDeliveryContext repository)
        {
            _repository = repository;
        }

        public async Task<MenuItem> Add(MenuItem entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<MenuItem>> GetAll() =>
            await Task.FromResult(_repository.MenuItem
                );

        public async Task<MenuItem> GetById(int? Id)
        {
            return await _repository.MenuItem
                .SingleOrDefaultAsync(item => item.IdRestaurant == Id.Value);
        }

        public async Task Remove(int? Id)
        {
            var menuItem = await GetById(Id);
            _repository.MenuItem.Remove(menuItem);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(MenuItem entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
    }
}

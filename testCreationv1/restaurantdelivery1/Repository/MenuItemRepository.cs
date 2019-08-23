using Microsoft.EntityFrameworkCore;
using restaurantdelivery1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantdelivery1.Repository
{
    public class MenuItemRepository : IRepository<MenuItem>
    {
        RestaurantContext _repository;

        public MenuItemRepository(RestaurantContext repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<MenuItem>> GetAll() =>
            await Task.FromResult(_repository.MenuItem
                .Include(res => res.IdRestaurantNavigation)
                );

        public async Task<MenuItem> Add(MenuItem entity)
        {
            await _repository.AddAsync(entity);
            _repository.SaveChanges();
            return entity;
        }

        public async Task<MenuItem> GetById(int? Id)
        {
            return await _repository.MenuItem
                  .SingleOrDefaultAsync(item => item.IdMenuItem == Id.Value);
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
        public Task SaveChangesAsync()
        {
            return Task.Run(() => {
                _repository.SaveChanges();
            });
        }
    }
}

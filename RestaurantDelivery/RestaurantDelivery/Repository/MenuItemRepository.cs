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

        public MenuItem GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(MenuItem entity)
        {
            throw new NotImplementedException();
        }
    }
}

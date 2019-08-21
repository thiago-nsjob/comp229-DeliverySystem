using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Repository
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        T GetById(int? Id);
        Task<T> Add(T entity);
        Task Remove(int? Id);

        Task Update(T entity);
    }
}

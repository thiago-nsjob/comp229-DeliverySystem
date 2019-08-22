using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantdelivery1.Repository
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int? Id);
        Task<T> Add(T entity);
        Task Remove(int? Id);
        Task Update(T entity);
    }
}

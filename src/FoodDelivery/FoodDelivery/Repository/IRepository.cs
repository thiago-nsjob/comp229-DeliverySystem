using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll { get; }
        T GetById(int? Id);
        void Add(T entity);
        void Remove(int? Id);

        void Update(T entity);
    }
}

using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        
        IQueryable<T> Table { get; }
        Task SaveChanges();
    }
}

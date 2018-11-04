using Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;
        private DbSet<T> entities;
        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            entities = _applicationContext.Set<T>();
        }
        public IQueryable<T> Table { get { return entities.AsNoTracking(); } }

        public Task  Delete(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");
            entities.Remove(entity);
           return Task.Run(() =>  _applicationContext.SaveChangesAsync());
        }

        public Task<T> Get(long id)
        {
            return entities.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.Run(() => entities.AsEnumerable());
        }

        public Task Insert(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");
              entities.Add(entity);
            return Task.Run(() => _applicationContext.SaveChangesAsync());
        }

      

        public  Task SaveChanges()
        {
            return Task.Run(() => _applicationContext.SaveChangesAsync());
        }

        public Task Update(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");

            return Task.Run(() => _applicationContext.SaveChangesAsync());
        }
    }
}

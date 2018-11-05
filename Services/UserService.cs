using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;
using Repositories;
using System.Linq;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users> _repository;
        public UserService(IRepository<Users> repository)
        {
            _repository = repository;
        }
        public Task Create(Users Users)
        {
            return _repository.Insert(Users);
        }

        public Task Delete(Users Users)
        {
            return _repository.Delete(Users);
        }

        public Task<Users> GetByEmail(string Email)
        {
            return Task.Run(() => _repository.Table.Where(c => c.Email == Email).SingleOrDefault());
        }

        public Task<Users> GetById(int Id)
        {
            return _repository.Get(Id);
        }

        public Task<IEnumerable<Users>> List()
        {
            return _repository.GetAll();
        }

        public Task Update(Users Users)
        {
            return _repository.Update(Users);
        }
    }
}

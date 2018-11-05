using Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task Create(Users Users);

        Task Update(Users Users);

        Task Delete(Users Users);

        Task<IEnumerable<Users>> List();

        Task<Users> GetById(int Id);
        Task<Users> GetByEmail(string Email);
    }
}

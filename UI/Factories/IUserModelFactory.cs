using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Factories
{
    public interface IUserModelFactory
    {
         Task<IEnumerable<UsersModel>> PrepareUsersListAsync();
        Task<UsersModel> PrepareUsersAsync(int id);
    }
}

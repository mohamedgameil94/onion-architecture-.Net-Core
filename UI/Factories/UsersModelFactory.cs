using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Factories
{
    public class UsersModelFactory : IUserModelFactory
    {
        private readonly IUserService _userService;
        public UsersModelFactory(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UsersModel> PrepareUsersAsync(int id)
        {
            var user = await _userService.GetById(id);
            return new UsersModel()
            {
                Id = user.Id,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                Password = user.Password.ToString(),
                Guid = user.Guid,
                LastUpdatedDate = user.LastUpdatedDate
            };
        }

        public async Task<IEnumerable<UsersModel>> PrepareUsersListAsync()
        {
            var Users = await _userService.List();
            return Users.Select(u => new UsersModel() {
                Id = u.Id,
                Email = u.Email,
                Guid = u.Guid,
                CreatedDate = u.CreatedDate,
                LastUpdatedDate = u.LastUpdatedDate,
                Password = u.Password.ToString()
            });
        }
    }
}

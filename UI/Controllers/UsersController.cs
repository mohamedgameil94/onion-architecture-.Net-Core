using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using UI.Factories;
using UI.Infrastructure;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserModelFactory _userModelFactory;
        private IEncryptionService _encryptionService;
        public UsersController(IUserService userService, IUserModelFactory userModelFactory, IEncryptionService encryptionService)
        {
            _userService = userService;
            _userModelFactory = userModelFactory;
            _encryptionService = encryptionService;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UsersModel>> Get()
        {
            return await _userModelFactory.PrepareUsersListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<UsersModel> Get(int id)
        {
            return await _userModelFactory.PrepareUsersAsync(id);
        }

        // POST: api/Users
        [HttpPost]
        [AllowAnonymous]
        public async Task Post([FromBody] UsersModel model)
        {
            byte[] passwordHash, passwordSalt;
            _encryptionService.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            var entity = new Users()
            {
                Id = model.Id,
                Email = model.Email,
                CreatedDate = DateTime.UtcNow,
                Guid = Guid.NewGuid(),
                Password = passwordHash,
                PasswordSalt = passwordSalt

            };
          await _userService.Create(entity);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task Put( [FromBody] UsersModel model)
        {
            byte[] passwordHash, passwordSalt;
            _encryptionService.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);

            var user = await _userService.GetById(model.Id);
            user.LastUpdatedDate = DateTime.UtcNow;
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userService.Update(user);
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var user = await _userService.GetById(id);
            await _userService.Delete(user);
        }
    }
}

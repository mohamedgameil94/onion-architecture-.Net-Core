using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using UI.Infrastructure;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenProvider _tokenProvider;
        private readonly IEncryptionService _encryptionService;
        public AuthenticationController(IUserService userService, ITokenProvider tokenProvider, IEncryptionService encryptionService)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _encryptionService = encryptionService;


        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]LoginInfoModel model)
        {

            var user = await _userService.GetByEmail(model.Email);
            if (user == null || !_encryptionService.VerifyPasswordHash(model.Password, user.Password, user.PasswordSalt))
                return BadRequest("invalid Email or password");

            string Token = _tokenProvider.GenerateTokenIdentity(user.Id.ToString(), DateTime.Now.AddDays(8));
            return Ok(new
            {
                Token,
                user.Email,
                Expires = DateTime.Now.AddDays(8)
            });
        }

    }
}

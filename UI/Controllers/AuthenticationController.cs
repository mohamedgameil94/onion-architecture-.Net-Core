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
        public AuthenticationController(IUserService userService, ITokenProvider tokenProvider)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]LoginInfoModel Model)
        {
            var user = await _userService.GetByEmail(Model.Email);
            if (user == null || (!user.Password.Equals(Model.Password)))
                return BadRequest("incorrect user name or password");

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

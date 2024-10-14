using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class AuthenticationController(IServiceManager serviceManager) : ApiController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDTO>> Login(LoginDTO loginModel)
        {
            var result = await serviceManager.AuthenticationService.LoginAsync(loginModel);

            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDTO>> Register(UserRegisterDTO  registerModel)
        {
            var result = await serviceManager.AuthenticationService.RegisterAsync(registerModel);

            return Ok(result);
        }
    }
}

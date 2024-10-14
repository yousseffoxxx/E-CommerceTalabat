using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService(UserManager<User> UserManager) : IAuthenticationService
    {
        public async Task<UserResultDTO> LoginAsync(LoginDTO loginModel)
        {
            // Check if there is user under this Email
            var user = await UserManager.FindByEmailAsync(loginModel.Email);
            if (user == null) throw new UnAuthorizedException("Email Doesn't Exist");

            // Check if password is correct for this Email
            var result = await UserManager.CheckPasswordAsync(user, loginModel.Password);
            if(!result == true) throw new UnAuthorizedException();

            // create Token and Return Response
            return new UserResultDTO(
                user.DisplayName,
                user.Email,
                "Token");

        }

        public Task<UserResultDTO> RegisterAsync(UserRegisterDTO registerModel)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<UserResultDTO> RegisterAsync(UserRegisterDTO registerModel)
        {

            var user = new User()
            {
                Email = registerModel.Email,
                DisplayName = registerModel.DisplayName,
                PhoneNumber = registerModel.PhoneNumber,
                UserName = registerModel.UserName,
            };

            var result = await UserManager.CreateAsync(user , registerModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                
                throw new ValidationException(errors); 
            }

            return new UserResultDTO(
                user.DisplayName,
                user.Email,
                "Token");

        }
    }
}

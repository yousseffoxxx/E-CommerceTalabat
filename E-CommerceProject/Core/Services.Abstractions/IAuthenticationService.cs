using Shared.AuthModels;

namespace Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<UserResultDTO> LoginAsync(LoginDTO loginModel);
        public Task<UserResultDTO> RegisterAsync(UserRegisterDTO registerModel);
    
        // Get Current User
        public Task<UserResultDTO> GetUserByEmail(string email);

        // check Email exist
        public Task<bool> CheckEmailExist(string email);

        // get user Address
        public Task<AddressDTO> GetUserAddress(string email);

        // Update user address
        public Task<AddressDTO> UpdateUserAddress(AddressDTO address, string email);
    }
}

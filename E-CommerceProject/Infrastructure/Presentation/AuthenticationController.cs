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

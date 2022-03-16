using AuthenticationMicroservice.BusinessLogic.Services.Interfaces;
using AuthenticationMicroservice.DAL.Repository.Interface;
using AuthenticationMicroservice.DTO;

namespace AuthenticationMicroservice.BusinessLogic.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationRepository _authenticationRepository;
        private ITokenService _tokenService;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, ITokenService tokenService)
        {
            _authenticationRepository = authenticationRepository;
            _tokenService = tokenService;
        }
        public string GenerateJWT(UserDetails userDetails)
        {
            return _tokenService.GenerateJWT(userDetails);
        }

        public UserDetails? VerifyLogin(LoginDetails loginDetails)
        {
            return _authenticationRepository.VerifyLogin(loginDetails);
        }
    }
}

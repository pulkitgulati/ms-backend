using AuthenticationMicroservice.DAL.Repository.Interface;
using AuthenticationMicroservice.DTO;

namespace AuthenticationMicroservice.DAL.Repository.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public UserDetails? VerifyLogin(LoginDetails loginDetails)
        {
            if (loginDetails.username == "demo" && loginDetails.password == "demo@123")
            {
                return new UserDetails() { displayName = "Demo Account", Authorization = "Name,Address,Notification" };
            }
            else
            {
                return null;
            }
        }
    }
}

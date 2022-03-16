using AuthenticationMicroservice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.DAL.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        UserDetails? VerifyLogin(LoginDetails loginDetails);
    }
}

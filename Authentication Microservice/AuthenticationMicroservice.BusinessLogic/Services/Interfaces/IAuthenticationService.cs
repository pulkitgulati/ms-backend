using AuthenticationMicroservice.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.BusinessLogic.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserDetails? VerifyLogin(LoginDetails loginDetails);
        string GenerateJWT(UserDetails userDetails);
    }
}

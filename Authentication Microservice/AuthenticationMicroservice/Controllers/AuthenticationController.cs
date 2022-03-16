
using AuthenticationMicroservice.BusinessLogic.Services.Interfaces;
using AuthenticationMicroservice.DTO;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthenticationMicroservice.Controllers
{
    [ApiController]
    [Route("Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Token")]
        public IActionResult GetToken(LoginDetails loginDetails)
        {
            if (loginDetails == null)
            {
                return BadRequest();
            }
            var validator = new LoginDetailsValidator();
            ValidationResult results = validator.Validate(loginDetails, options => options.IncludeRuleSets("Shared"));
            results.AddToModelState(ModelState, null);
            if (ModelState.ErrorCount > 0)
            {
                return BadRequest(ModelState);
            }
            UserDetails? userDetails = _authenticationService.VerifyLogin(loginDetails);
            if (userDetails != null && !string.IsNullOrEmpty(userDetails.displayName))
            {
                var tokenString = _authenticationService.GenerateJWT(userDetails);
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
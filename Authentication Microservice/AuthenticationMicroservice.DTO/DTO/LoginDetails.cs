using FluentValidation;
namespace AuthenticationMicroservice.DTO
{
    public class LoginDetails
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginDetailsValidator : AbstractValidator<LoginDetails>
    {
        public LoginDetailsValidator()
        {
            RuleSet("Shared", () =>
            {
                RuleFor(x => x.username).NotNull().NotEmpty();
                RuleFor(x => x.password).NotNull().NotEmpty();
            });
        }
    }
}

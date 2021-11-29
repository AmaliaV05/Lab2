using FluentValidation;
using Project2.Data;
using Project2.ViewModels.Authentication;

namespace Project2.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly ApplicationDbContext _context;

        public LoginRequestValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}

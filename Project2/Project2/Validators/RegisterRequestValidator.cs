using FluentValidation;
using Project2.Data;
using Project2.ViewModels.Authentication;

namespace Project2.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly ApplicationDbContext _context;

        public RegisterRequestValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().Length(6, 100);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);           
        }
    }
}

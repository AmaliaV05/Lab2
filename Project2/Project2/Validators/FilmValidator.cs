using FluentValidation;
using Project2.Data;
using Project2.Models;
using Project2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Validators
{
    public class FilmValidator : AbstractValidator<FilmViewModel>
    {
        private readonly ApplicationDbContext _context;

        public FilmValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Description).MinimumLength(20);
            RuleFor(x => x.Rating).InclusiveBetween(1, 10);
            RuleFor(x => x.Genre).Custom((prop, validationContext) =>
            {
                var instance = validationContext.InstanceToValidate;
                int commentsForGenre = _context.Comments.Where(c => c.Film.Genre == instance.Genre).Count();
                if (commentsForGenre > 10)
                {
                    validationContext.AddFailure($"Cannot add a film with genre {instance.Genre} because that genre has more than 10 comments: it has {commentsForGenre}.");
                }
            });
        }
    }
}

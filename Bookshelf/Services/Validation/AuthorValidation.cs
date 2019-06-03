using FluentValidation;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Validation
{
    public class AuthorValidation : AbstractValidator<AuthorServ>
    {
        public AuthorValidation()
        {
            RuleFor(a => a.Name).NotEmpty().Length(1, 100).WithMessage("Please specify a title");
            RuleFor(a => a.AuthorId).NotEmpty();
        }
    }
}


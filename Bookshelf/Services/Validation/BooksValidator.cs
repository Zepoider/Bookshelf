using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Validation
{
    public class BooksValidator : AbstractValidator<BooksServ>
    {
    public BooksValidator()
    {
            RuleFor(a => a.ActualPrice).NotEmpty().GreaterThan(0).WithErrorCode("Invalide");
            RuleFor(a => a.OrgPrice).NotEmpty().GreaterThan(0);
            RuleFor(a => a.Title).NotEmpty().Length(1, 100).WithMessage("Please specify a title");
            RuleFor(a => a.BooksId).NotEmpty();
        }
    }
}

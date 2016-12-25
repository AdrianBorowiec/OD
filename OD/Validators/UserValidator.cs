using FluentValidation;
using OD.Models;

namespace OD.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Nickname).NotEmpty();
            RuleFor(x => x.Nickname).Length(0, 50);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}

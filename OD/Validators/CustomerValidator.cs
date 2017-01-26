using FluentValidation;
using OD.Models;

namespace OD.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Nickname).NotEmpty().Length(1, 25).WithMessage("Nazwa użytkownika może mieć maksymalnie 25 znaków!");
            RuleFor(x => x.Password).NotEmpty().Length(6, 25).WithMessage("Hasło musi mieć minimum 6 znaków!");
        }
    }
}

using FluentValidation;
using OD.Models;

namespace OD.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Producer).NotEmpty();
        }
    }
}

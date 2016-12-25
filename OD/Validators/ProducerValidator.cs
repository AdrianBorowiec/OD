using FluentValidation;
using OD.Models;

namespace OD.Domain.Validators
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ApartmentNumber).NotEmpty();
            RuleFor(x => x.ApartmentNumber).Length(0, 15);
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.Street).Length(0, 50);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).Length(0, 50);
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Country).Length(0, 50);
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.PhoneNumber).Length(0, 20);
        }
    }
}

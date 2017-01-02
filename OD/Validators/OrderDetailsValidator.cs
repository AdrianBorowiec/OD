using FluentValidation;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Validators
{
    public class OrderDetailsValidator : AbstractValidator<OrderDetails>
    {
        public OrderDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Order).NotEmpty();
            RuleFor(x => x.Product).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
        }
    }
}
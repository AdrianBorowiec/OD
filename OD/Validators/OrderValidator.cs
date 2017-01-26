using FluentValidation;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Customer).NotEmpty();
            RuleFor(x => x.OrderStatus).NotEmpty();
            RuleFor(x => x.OrderDT).NotEmpty();
        }
    }
}
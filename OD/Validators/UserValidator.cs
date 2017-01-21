using FluentValidation;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Validators
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
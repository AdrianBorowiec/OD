using FluentValidation;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Validators
{
    public class UsersValidator : AbstractValidator<Users>
    {

        public UsersValidator()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
using FluentValidation.Attributes;
using OD.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OD.Models
{
    [Validator(typeof(UsersValidator))]
    public class Users
    {
      
        public int Id { get; set; }

       
        public string Name { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set;}

        public string Email { get; set; }

        public Users()
        {

        }
    }
}
using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Models
{
    /// <summary>
    /// Użytkownik
    /// </summary>
    [Validator(typeof(UserValidator))]
    public class User
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Imię.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Miasto.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Kraj.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Nickname.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Hasło.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Numer telefonu.
        /// </summary>
        public string PhoneNumber { get; set; }

        public User()
        {
        }
    }
}
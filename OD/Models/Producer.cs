using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OD.Models
{
    /// <summary>
    /// Producent
    /// </summary>
    [Bind(Include = "Id, Name")]
    [Validator(typeof(ProducerValidator))]
    public class Producer
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa dostawcy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Numer domu/mieszkania.
        /// </summary>
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// Ulica. 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Miasto.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Kraj.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Numer telefonu.
        /// </summary>
        public string PhoneNumber { get; set; }

        public Producer()
        {
        }
    }
}
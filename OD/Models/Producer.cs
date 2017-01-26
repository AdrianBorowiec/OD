using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa dostawcy
        /// </summary>
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        /// <summary>
        /// Numer domu/mieszkania
        /// </summary>
        [Display(Name = "Numer domu/mieszkania")]
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// Ulica
        /// </summary>
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        [Display(Name = "Miasto")]
        public string City { get; set; }

        /// <summary>
        /// Kraj
        /// </summary>
        [Display(Name = "Kraj")]
        public string Country { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        public Producer()
        {
        }
    }
}
using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OD.Models
{
    /// <summary>
    /// Klient.
    /// </summary>
    [Validator(typeof(CustomerValidator))]
    public class Customer
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa użytownika.
        /// </summary>
        [Display(Name = "Nazwa użytownika")]
        public string Nickname { get; set; }

        /// <summary>
        /// Hasło.
        /// </summary>
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Powtórz hasło.
        /// </summary>
        [Display(Name = "Powtórz hasło")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string CheckPassword { get; set; }

        /// <summary>
        /// Lista zamówień.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}
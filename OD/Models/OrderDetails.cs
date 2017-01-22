using FluentValidation.Attributes;
using OD.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OD.Models
{
    /// <summary>
    /// Detale zamówienia.
    /// </summary>
    [Validator(typeof(OrderDetailsValidator))]
    public class OrderDetails
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Zamówienie.
        /// </summary>
        [Display(Name = "Zamówienie")]
        public virtual Order Order { get; set; }

        /// <summary>
        /// Produkt.
        /// </summary>
        [Display(Name = "Produkt")]
        public virtual Product Product { get; set; }

        /// <summary>
        /// Ilość produktu.
        /// </summary>
        [Display(Name = "Ilość")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Łączna wartość produktu.
        /// </summary>
        [Display(Name = "Łączna wartość")]
        public int? TotalAmount { get; set; }

        public OrderDetails()
        {
        }
    }
}
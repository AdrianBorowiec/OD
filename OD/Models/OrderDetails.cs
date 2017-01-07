using FluentValidation.Attributes;
using OD.Validators;
using System;
using System.Collections.Generic;
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
        public int? Id { get; set; }

        /// <summary>
        /// Zamówienie.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Ilość produktu.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Wartośc jednej jednostki produktu.
        /// </summary>
        public int? UnitPrice { get; set; }

        /// <summary>
        /// Łączna wartość produktu.
        /// </summary>
        public int? TotalAmount { get; set; }

        public OrderDetails()
        {
        }
    }
}
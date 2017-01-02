using FluentValidation.Attributes;
using OD.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Models
{
    /// <summary>
    /// Zamówienie.
    /// </summary>
    [Validator(typeof(OrderValidator))]
    public class Order
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Identyfikator klienta.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Data utworzenia zamówienia.
        /// </summary>
        public DateTime? OrderCreateDT { get; set; }

        /// <summary>
        /// Wartośc zamówienia.
        /// </summary>
        public int? TotalAmount { get; set; }

        /// <summary>
        /// Status zamówienia.
        /// </summary>
        public OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Detale zamówienia.
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
    }

    public enum OrderStatus
    {
        Nowe,
        Utworzone,
        Dostarczone,
        Anulowane
    }
}
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
    /// Zamówienie.
    /// </summary>
    [Validator(typeof(OrderValidator))]
    public class Order
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Klient.
        /// </summary>
        [Display(Name = "Klient")]
        public virtual Customer Customer { get; set; }
        // tutaaj powinno byc odwolanie do aktualnie zalogowanego klienta czyli np CustomerContext

        /// <summary>
        /// Data utworzenia zamówienia.
        /// </summary>
        [Display(Name = "Data utworzenia")]
        public DateTime? OrderDT { get; set; }

        /// <summary>
        /// Wartośc zamówienia.
        /// </summary>
        [Display(Name = "Wartośc")]
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Status zamówienia.
        /// </summary>
        [Display(Name = "Status")]
        public OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Detale zamówienia.
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
            this.OrderDT = DateTime.Now;
            //this.Id
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
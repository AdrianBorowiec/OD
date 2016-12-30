using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OD.Models
{
    /// <summary>
    /// Produkt
    /// </summary>
    [Validator(typeof(ProductValidator))]
    public class Product
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa produktu.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cena produktu.
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// Typ produktu.
        /// </summary>
        //public ProductType ProductType { get; set; }
        public ProductTypeEnum? ProductType { get; set; }

        /// <summary>
        /// Producent.
        /// </summary>
        public virtual Producer Producer { get; set; }

        /// <summary>
        /// Ścieżka do zdjęcia (folder ~/Images/Products)
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Dostępna ilośc produktu.
        /// </summary>
        public int? Quantity { get; set; }

        public Product()
        {
        }
    }

    public enum ProductTypeEnum
    {
        Niezdefiniowane = 1,
        Batonik = 2,
        Cukierki = 3,
        Żelki = 4,
        Czekolada = 5,
        Ciasteczka = 6,
        Praliny = 7
    };
}
using FluentValidation.Attributes;
using OD.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa
        /// </summary>
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        /// <summary>
        /// Cena
        /// </summary>
        [Display(Name = "Cena")]
        public int? Price { get; set; }

        /// <summary>
        /// Typ
        /// </summary>
        [Display(Name = "Typ")]
        public ProductTypeEnum? ProductType { get; set; }

        /// <summary>
        /// Producent
        /// </summary>
        [Display(Name = "Producent")]
        public virtual Producer Producer { get; set; }

        /// <summary>
        /// Ścieżka do zdjęcia (folder ~/Images/Products)
        /// </summary>
        [Display(Name = "Ścieżka do zdjęcia")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Dostępna ilośc
        /// </summary>
        [Display(Name = "Dostępna ilośc")]
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
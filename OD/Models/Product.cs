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
        /// Ścieżka do zdjęcia (folder ~/ProductImages)
        /// </summary>
        public string ImageUrl { get; set; }

        public Product()
        {
        }
    }

    public enum ProductTypeEnum
    {
        None = 1,
        CandyBar = 2,
        Candy = 3,
        Jelly = 4,
        Chocolate = 5,
        Cookies = 6,
        Praline = 7
    };
}
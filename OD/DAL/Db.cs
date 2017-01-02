using OD.Configurations;
using OD.Infrastructure;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OD.DAL
{
    public class Db : DbContext
    {
        public Db()
            : base("ConnectionString")
        {
        }

        /// <summary>
        /// Tabele.
        /// </summary>
        #region DO UZUPEŁNIANIA - Tabele w bazie danych. Sortowane alfabetycznie!

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia ogólne.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());
            this.Configuration.LazyLoadingEnabled = true;

            /// <summary>
            /// Konfiguracje tabeli.
            /// </summary>
            #region DO UZUPEŁNIANIA - Konfiguracje dotyczące każdej tabeli w bazie danych

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProducerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());

            #endregion
        }
    }
}
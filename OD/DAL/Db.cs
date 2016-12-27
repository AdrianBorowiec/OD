using OD.Domain.Configurations;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia ogólne.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());

            /// <summary>
            /// Konfiguracje tabeli.
            /// </summary>
            #region DO UZUPEŁNIANIA - Konfiguracje dotyczące każdej tabeli w bazie danych

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProducerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            #endregion
        }
    }
}
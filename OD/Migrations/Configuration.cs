namespace OD.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Db ctx)
        {
            var users = new List<Customer>
            {
                new Customer { FirstName = "Adrian", LastName = "Borowiec", City = "Poznañ", Country = "Polska", Nickname = "Boro", Password = "pw", PhoneNumber = "606221460" },
                new Customer { FirstName = "Kamila", LastName = "Ziemba", City = "Poznañ", Country = "Polska", Nickname = "Kama", Password = "pw", PhoneNumber = "725323006" },
                new Customer { FirstName = "Agnieszka", LastName = "Pastwa", City = "Czersk", Country = "Polska", Nickname = "Aga", Password = "pw", PhoneNumber = "662612291" }
            };

            users.ForEach(x => ctx.Customers.AddOrUpdate(n => n.Nickname, x));
            ctx.SaveChanges();


            var producers = new List<Producer>
            {
                new Producer { Name = "Ferrero", City = "Alba", Country = "W³ochy", ApartmentNumber = "1", Street = "Piazzale Pietro Ferrero", PhoneNumber = "(+39) 0039 0173 295111" },
                new Producer { Name = "Wedel", City = "Warszawa", Country = "Polska", ApartmentNumber = "28/30", Street = "Zamoyskiego", PhoneNumber = "(+48) 226 707 700" },
                new Producer { Name = "Mars Incorporated", City = "McLean", Country = "USA", ApartmentNumber = "6885", Street = "Elm", PhoneNumber = "(+1) 703-821-4900" }
            };

            producers.ForEach(x => ctx.Producers.AddOrUpdate(n => n.Name, x));
            ctx.SaveChanges();


            var products = new List<Product>
            {
                new Product { Name = "Ferrero Rocher", Price = 12, ProductType = ProductTypeEnum.Praliny, Producer = ctx.Producers.FirstOrDefault(x => x.Name == "Ferrero"), ImageUrl = "~/Images/Products/FerreroRocher.jpg", Quantity = 20 },
                new Product { Name = "Kinder Bueno", Price = 4, ProductType = ProductTypeEnum.Batonik, Producer = ctx.Producers.FirstOrDefault(x => x.Name == "Ferrero"), ImageUrl = "~/Images/Products/FerreroKinderBueno.jpg", Quantity = 20 },
                new Product { Name = "Mleczna Czekolada", Price = 10, ProductType = ProductTypeEnum.Czekolada, Producer = ctx.Producers.FirstOrDefault(x => x.Name == "Wedel"), ImageUrl = "~/Images/Products/WedelMlecznaCzekolada.jpg", Quantity = 20 },
                new Product { Name = "WW", Price = 4, ProductType = ProductTypeEnum.Batonik, Producer = ctx.Producers.FirstOrDefault(x => x.Name == "Wedel"), ImageUrl = "~/Images/Products/WedelWW.jpg", Quantity = 20 },
                new Product { Name = "Snickers", Price = 3, ProductType = ProductTypeEnum.Batonik, Producer = ctx.Producers.FirstOrDefault(x => x.Name == "Mars Incorporated"), ImageUrl = "~/Images/Products/MarsIncorporatedSnickers.jpg", Quantity = 20 }
            };

            products.ForEach(x => ctx.Products.AddOrUpdate(n => n.Name, x));
            ctx.SaveChanges();
        }
    }
}

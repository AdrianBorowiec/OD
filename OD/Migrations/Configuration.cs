namespace OD.Migrations
{
    using Models;
    using System;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            ctx.Users.AddOrUpdate(
                new User { FirstName = "Adrian", LastName = "Borowiec", City = "Poznan", Country = "Polska", Nickname = "Boro", Password = "pw", PhoneNumber = "606221460" },
                new User { FirstName = "Kamila", LastName = "Ziemba", City = "Poznan", Country = "Polska", Nickname = "Kama", Password = "pw", PhoneNumber = "725323006" },
                new User { FirstName = "Agnieszka", LastName = "Pastwa", City = "Czersk", Country = "Polska", Nickname = "Aga", Password = "pw", PhoneNumber = "662612291" }
                );
        }
    }
}

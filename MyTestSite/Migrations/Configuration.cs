namespace MyTestSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyTestSite.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTestSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyTestSite.Models.ApplicationDbContext";
        }

        protected override void Seed(MyTestSite.Models.ApplicationDbContext context)
        {
            context.Products.AddOrUpdate(p => p.ProductId,
                new Product { Name = "Potion1", Price = 10, Category = "potion", Description = "aaa"},
                new Product { Name = "Potion2", Price = 11, Category = "potion", Description = "bbb" },
                new Product { Name = "Potion3", Price = 12, Category = "potion", Description = "ccc" },
                new Product { Name = "Potion4", Price = 13, Category = "potion", Description = "ddd" },
                new Product { Name = "Potion5", Price = 10, Category = "potion", Description = "aaa" },
                new Product { Name = "Potion6", Price = 11, Category = "potion", Description = "bbb" },
                new Product { Name = "Potion7", Price = 12, Category = "potion", Description = "ccc" },
                new Product { Name = "Potion8", Price = 13, Category = "potion", Description = "ddd" },
                new Product { Name = "Artefact1", Price = 10, Category = "artefact", Description = "aaa" },
                new Product { Name = "Artefact2", Price = 11, Category = "artefact", Description = "bbb" },
                new Product { Name = "Artefact3", Price = 12, Category = "artefact", Description = "ccc" },
                new Product { Name = "Artefact4", Price = 13, Category = "artefact", Description = "ddd" },
                new Product { Name = "Artefact5", Price = 10, Category = "artefact", Description = "aaa" },
                new Product { Name = "Artefact6", Price = 11, Category = "artefact", Description = "bbb" },
                new Product { Name = "Artefact7", Price = 12, Category = "artefact", Description = "ccc" },
                new Product { Name = "Artefact8", Price = 13, Category = "artefact", Description = "ddd" },
                new Product { Name = "Ointment1", Price = 10, Category = "ointment", Description = "aaa" },
                new Product { Name = "Ointment2", Price = 11, Category = "ointment", Description = "bbb" },
                new Product { Name = "Ointment3", Price = 12, Category = "ointment", Description = "ccc" },
                new Product { Name = "Ointment4", Price = 13, Category = "ointment", Description = "ddd" },
                new Product { Name = "Ointment5", Price = 10, Category = "ointment", Description = "aaa" },
                new Product { Name = "Ointment6", Price = 11, Category = "ointment", Description = "bbb" },
                new Product { Name = "Ointment7", Price = 12, Category = "ointment", Description = "ccc" },
                new Product { Name = "Ointment8", Price = 13, Category = "ointment", Description = "ddd" },
                new Product { Name = "Item1", Price = 10, Category = "enchantedItem", Description = "aaa" },
                new Product { Name = "Item2", Price = 11, Category = "enchantedItem", Description = "bbb" },
                new Product { Name = "Item3", Price = 12, Category = "enchantedItem", Description = "ccc" },
                new Product { Name = "Item4", Price = 13, Category = "enchantedItem", Description = "ddd" },
                new Product { Name = "Item5", Price = 10, Category = "enchantedItem", Description = "aaa" },
                new Product { Name = "Item6", Price = 11, Category = "enchantedItem", Description = "bbb" },
                new Product { Name = "Item7", Price = 12, Category = "enchantedItem", Description = "ccc" },
                new Product { Name = "Item8", Price = 13, Category = "enchantedItem", Description = "ddd" }
                );

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "aa@aa.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "aa@aa.com", Email = "aa@aa.com" };

                manager.Create(user, "!myPassword1");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "bb@bb.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "bb@bb.com", Email = "bb@bb.com" };

                manager.Create(user, "!myPassword1");
                manager.AddToRole(user.Id, "User");
            }

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
        }
    }
}

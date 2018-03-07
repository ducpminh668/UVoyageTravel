namespace UvoyageTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<UvoyageTravel.Models.Entity.UvoyageDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UvoyageTravel.Models.Entity.UvoyageDBContext context)
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

            //var a = HttpContext.Current.Server.MapPath("~/Views/Shared/Footer.html");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", @"Views/Shared/Footer.html");
            //string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Footer.html");
            context.Footers.AddOrUpdate(
                  p => p.Content,
                  new Models.Entity.Footer { Content = File.ReadAllText(filePath) }
                );


        }
    }
}
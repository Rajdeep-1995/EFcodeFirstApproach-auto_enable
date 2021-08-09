namespace EFDbFirstApproach.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbFirstApproach.Models.CompanyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EFDbFirstApproach.Models.CompanyDBContext";
        }

        protected override void Seed(EFDbFirstApproach.Models.CompanyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Apple" }, new Models.Brand() { BrandID = 2, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1,CategoryName="Electronics" },new Models.Category(){ CategoryID = 2,CategoryName = "Appliances" });
            context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName = "Iphone 12", CategoryID = 1, BrandID = 1, Price = 1000, DateOfPurchase = DateTime.Now, Active = true,AvailabilityStatus="InStock", });
        }
    }
}

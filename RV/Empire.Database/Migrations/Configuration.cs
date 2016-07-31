using System;
using System.Data.Entity.Migrations;
using Empire.Database.Entities;

namespace Empire.Database.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<Contexts.EmpireContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Contexts.EmpireContext context)
		{
			context.Products.AddOrUpdate(x => x.Id,
				new Product
				{
					Id = 1,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					Name = "PURE WHEY"
				}, new Product
				{
					Id = 2,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					Name = "RECOVERY BCAA-G"
				});

			context.ProductDetails.AddOrUpdate(x => x.Id,
				new ProductDetail
				{
					Id = 1,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					Description = "PURE WHEY DESCRIPTION",
					Price = 33.90m,
					ProductId = 1
				},
				new ProductDetail
				{
					Id = 2,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					Description = "RECOVERY BCAA-G DESCRIPTION",
					Price = 33.90m,
					ProductId = 2
				});
		}
	}
}

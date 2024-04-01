using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
	internal class ProductSeed : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(new Product
			{
				Id = 1,
				CategoryId = 1,
				Name = "Telefon 1",
				CreatedDate = DateTime.Now,
				UnitPrice = 100,
				Stock = 200
			},
		   new Product
		   {
			   Id = 2,
			   CategoryId = 1,
			   Name = "Telefon 2",
			   CreatedDate = DateTime.Now,
			   UnitPrice = 40,
			   Stock = 80
		   },
		   new Product
		   {
			   Id = 3,
			   CategoryId = 2,
			   Name = "Bilgisayar 1",
			   CreatedDate = DateTime.Now,
			   UnitPrice = 100,
			   Stock = 1000
		   },
			new Product
			{
				Id = 4,
				CategoryId = 2,
				Name = "Bilgisayar 2",
				CreatedDate = DateTime.Now,
				UnitPrice = 70,
				Stock = 1500
			},
			 new Product
			 {
				 Id = 5,
				 CategoryId = 2,
				 Name = "Bilgisayar 3",
				 CreatedDate = DateTime.Now,
				 UnitPrice = 2200,
				 Stock = 35
			 },
			  new Product
			  {
				  Id = 6,
				  CategoryId = 3,
				  Name = "Manav 1",
				  CreatedDate = DateTime.Now,
				  UnitPrice = 10,
				  Stock = 1000
			  });
		}
	}
}

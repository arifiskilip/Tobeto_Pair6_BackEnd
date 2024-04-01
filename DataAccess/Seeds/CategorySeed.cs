using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
	internal class CategorySeed : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				Id = 1,
				Name = "Telefon",
				CreatedDate = DateTime.Now,
			},
		   new Category
		   {
			   Id = 2,
			   Name = "Bilgisayar",
			   CreatedDate = DateTime.Now,
		   },
		   new Category
		   {
			   Id = 3,
			   Name = "Manav",
			   CreatedDate = DateTime.Now,
		   });
		}
	}
}

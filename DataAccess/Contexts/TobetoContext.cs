using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Contexts
{
	public class TobetoContext : DbContext
	{
		public TobetoContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
			// IEntityConfigurations refarnsı sahip olan tüm assembly (class) oku ve al.
		}
	}
}

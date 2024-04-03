using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using DataAccess.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
	public static class DataAccessServiceRegistration
	{
		public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
		{
			services.AddDbContext<TobetoContext>(opt =>
			{
				opt.UseSqlServer(Connection.GetConnection);
			});

			services.AddScoped<IProductDal, ProductDal>();
			
			return services;
		}
	}
}

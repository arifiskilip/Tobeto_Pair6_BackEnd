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
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});
			services.AddScoped<IProductDal, ProductDal>();
			services.AddScoped<IUserDal, UserDal>();
			services.AddScoped<IRoleDal, RoleDal>();
			services.AddScoped<IUserRoleDal, UserRoleDal>();
			
			return services;
		}
	}
}

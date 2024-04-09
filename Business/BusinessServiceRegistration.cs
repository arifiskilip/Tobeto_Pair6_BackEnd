using Business.Abstract;
using Business.Concrete;
using Business.Features.Products.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
	public static class BusinessServiceRegistration
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services)
		{
			services.AddMediatR(config => {
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			});
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped(typeof(ProductBusinessRules));
			//Autom Mapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//MediatR
			
			return services;
		}
	}
}

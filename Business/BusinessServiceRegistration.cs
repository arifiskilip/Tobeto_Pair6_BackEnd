using Business.Abstract;
using Business.Concrete;
using Business.Features.Auth.Rules;
using Business.Features.Products.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
	public static class BusinessServiceRegistration
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services)
		{
			
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IUserService, UserManager>();
			services.AddScoped<IAuthService, AuthManager>();
			services.AddScoped<IUserRoleService, UserRoleManager>();

			services.AddScoped(typeof(ProductBusinessRules));
			services.AddScoped(typeof(AuthBusinessRules));
			//Autom Mapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//Fluent Validation
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			//MediatR
			services.AddMediatR(config => {
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
				config.AddOpenBehavior(typeof(ValidationBehavior<,>));
			});

			return services;
		}
	}
}

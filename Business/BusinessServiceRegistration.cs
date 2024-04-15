using Business.Abstract;
using Business.Concrete;
using Business.Features.Products.Rules;
using Business.Features.Products.Validations;
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
			services.AddScoped(typeof(ProductBusinessRules));
			//Autom Mapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//Fluent Validation
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			//MediatR
			services.AddMediatR(config => {
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				config.AddOpenBehavior(typeof(ValidationBehavior<,>));
			});

			return services;
		}
	}
}

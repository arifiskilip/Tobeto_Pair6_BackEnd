﻿using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
	public static class BusinessServiceRegistration
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductManager>();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}

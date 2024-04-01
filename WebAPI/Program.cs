using Business.Abstract;
using Business.Concrete;
using Core.CrossCuttingConcers.Exceptions.Extensions;
using Core.CrossCuttingConcers.ExceptionsV2;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//IoC
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, ProductDal>();

//Add DbContext
builder.Services.AddDbContext<TobetoContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();
//app.UseMiddleware<ExceptionMiddlewareV2>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

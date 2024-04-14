using AutoMapper;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Entities.Concrete;

namespace Business.Features.Products.Profiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<CreateProductCommand, Product>().ReverseMap();
			CreateMap<CreateProductResponse, Product>().ReverseMap();
				
			CreateMap<UpdateProductCommand, Product>().ReverseMap();
			CreateMap<Product, UpdateProductResponse>().ForMember(dest=> dest.CategoryName,opt=>opt.MapFrom(src=>src.Category.Name)).ReverseMap();
			
			CreateMap<Product, GetByIdProductResponse>().ForMember(dest=> dest.CategoryName, opt=> opt.MapFrom(src=> src.Category.Name)).ReverseMap();
		}
	}
}

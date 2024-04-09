using AutoMapper;
using Business.Features.Products.Commands.Create;
using Entities.Concrete;

namespace Business.Features.Products.Profiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<CreateProductCommand, Product>().ReverseMap();
			CreateMap<CreateProductResponse, Product>().ReverseMap();
		}
	}
}

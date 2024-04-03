using AutoMapper;
using Business.Dtos.Request.Product;
using Business.Dtos.Response;
using Entities.Concrete;

namespace Business.Profiles
{
	public class ProductProfile : Profile
	{
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>().ReverseMap();
            CreateMap<CreateProductResponse, Product>().ReverseMap();
            CreateMap<DeleteProductRequest, Product>().ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<UpdateProductResponse, Product>().ReverseMap();
            CreateMap<GetAllProductResponse, Product>().ReverseMap();
            CreateMap<GetProductResponse, Product>().ReverseMap();
        }
    }
}

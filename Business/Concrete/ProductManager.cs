using AutoMapper;
using Business.Abstract;
using Business.Dtos.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;
	private readonly IMapper _mapper;

	public ProductManager(IProductDal productDal, IMapper mapper)
	{
		_productDal = productDal;
		_mapper = mapper;
	}

	public Task<CreateProductResponse> AddAsync(Product product)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<GetAllProductResponse>> GetAllAsync()
	{
		var products = await _productDal.GetListAsync();
		products.Include(x => x.Category);
		var result = _mapper.Map<List<GetAllProductResponse>>(products);
		return result;

	}

	public Task<GetProductResponse> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<UpdateProductResponse> UpdateAsync(Product product)
	{
		throw new NotImplementedException();
	}
}

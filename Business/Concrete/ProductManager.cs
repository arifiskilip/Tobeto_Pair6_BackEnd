using AutoMapper;
using Business.Abstract;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;

	public ProductManager(IProductDal productDal, IMapper mapper)
	{
		_productDal = productDal;
	}

	public Task<Product> AddAsync(Product product)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IPaginatedList<Product>> GetAllAsync(int index=1, int size=10)
	{
		var products = await _productDal.GetListAsync
			(
				include: x => x.Include(x => x.Category),
				orderBy:x=> x.OrderByDescending(x=>x.CreatedDate),
				index: index,
				size:size
			);
		return products;

	}

	public Task<Product> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<Product> UpdateAsync(Product product)
	{
		throw new NotImplementedException();
	}
}

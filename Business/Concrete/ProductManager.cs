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

	public async Task<Product> AddAsync(Product product)
	{
		var checkProduct = await _productDal.GetAsync(
			predicate: x => x.Id == product.Id);
		if (checkProduct != null)
		{
			throw new Exception("Ürün mevcut değil!");
		}
		return await _productDal.AddAsync(
			entity: product,
			includeProperties: x => x.Category);
	}

	public async Task DeleteAsync(int id)
	{
		var checkProduct = await _productDal.GetAsync(
			predicate: x => x.Id == id,
			enableTracking:true);
		if (checkProduct != null)
		{
			await _productDal.DeleteAsync(checkProduct);
		}
		else
		{
			throw new Exception("Ürün mevcut değil!");
		}
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

	public async Task<Product> GetByIdAsync(int id)
	{
		var checkProduct = await _productDal.GetAsync(
			predicate: x => x.Id == id,
			include: x => x.Include(x => x.Category));
		if (checkProduct != null)
		{
			return checkProduct;
		}
		throw new Exception("Ürün mevcut değil!");
	}

	public async Task<Product> UpdateAsync(Product product)
	{
		var checkProduct = await _productDal.GetAsync(
			predicate: x => x.Id == product.Id);
		if (checkProduct != null)
		{
			return await _productDal.UpdateAsync(
			entity: product,
			includeProperties: x => x.Category);
		}
		throw new Exception("Ürün mevcut değil!");
	}
}
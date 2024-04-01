using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;

	public ProductManager(IProductDal productDal)
	{
		_productDal = productDal;
	}

	public Task<Product> AddAsync(Product product)
	{
		var addedProduct = _productDal.AddAsync(product);
		if (product != null)
		{
			return addedProduct;
		}
	    throw new Exception("Ekleme hatası!");
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Product>> GetAllAsync()
	{
		throw new NotImplementedException();
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

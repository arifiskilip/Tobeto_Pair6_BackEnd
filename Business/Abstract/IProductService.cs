using Core.DataAccess.Paging;
using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
	Task<IPaginatedList<Product>> GetAllAsync(int index = 1, int size = 10);
	Task<Product> GetByIdAsync(int id);
	Task<Product> AddAsync(Product product);
	Task<Product> UpdateAsync(Product product);
	Task DeleteAsync(int id);
}

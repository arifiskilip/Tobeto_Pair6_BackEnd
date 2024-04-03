using Business.Dtos.Response;
using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
	Task<List<GetAllProductResponse>> GetAllAsync();
	Task<GetProductResponse> GetByIdAsync(int id);
	Task<CreateProductResponse> AddAsync(Product product);
	Task<UpdateProductResponse> UpdateAsync(Product product);
	Task DeleteAsync(int id);
}

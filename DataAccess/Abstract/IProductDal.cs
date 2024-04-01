using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IProductDal : IRepository<Product,int>, IAsyncRepository<Product,int>
	{
	}
}

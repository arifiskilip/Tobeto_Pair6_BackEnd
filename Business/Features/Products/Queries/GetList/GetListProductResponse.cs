using Core.DataAccess.Paging;
using Entities.Concrete;

namespace Business.Features.Products.Queries.GetList
{
	public class GetListProductResponse 
	{

		public IPaginatedList<Product> Datas { get; set; }

    }
}

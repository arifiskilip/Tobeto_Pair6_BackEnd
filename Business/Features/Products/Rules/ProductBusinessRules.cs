using DataAccess.Abstract;

namespace Business.Features.Products.Rules
{
	public class ProductBusinessRules
	{
		private readonly IProductDal _productDal;

		public ProductBusinessRules(IProductDal productDal)
		{
			_productDal = productDal;
		}


		public async Task DuplicateNameCheckAsync(string name)
		{
			var check = await _productDal.AnyAsync(x=>x.Name.ToLower() == name.ToLower());
			if (check)
			{
				throw new Exception("Bu ürün adı zaten mevcut!");
			}
		}
		public async Task UpdateProductDuplicateNameCheckAsync(string name,int id)
		{
			var check = await _productDal.GetAsync(x => x.Name.ToLower() == name.ToLower());
			if (check != null && check.Id != id)
			{
				throw new Exception("Bu ürün adı zaten mevcut!");
			}
		}
	}
}

using Business.Abstract;
using Core.CrossCuttingConcers.Exceptions.Types;
using Core.CrossCuttingConcers.ExceptionsV2.Type;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using ValidationException = Core.CrossCuttingConcers.Exceptions.Types.ValidationException;
using ValidationExceptionModel = Core.CrossCuttingConcers.Exceptions.Types.ValidationExceptionModel;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] Product product)
		{
			if (product.Name=="a")
			{
				throw new NatFounEx("Bulunamadı!");
			}
			else if(product.Name=="b"){
				throw new ValidationEx("Validasyon hata2");
			}
			else if(product.Name == "c")
			{
				throw new ValidationException(new List<ValidationExceptionModel>() { new ValidationExceptionModel() { Errors = new List<string> { "test1", "test2" }, Property = "Deneme Property" } });
			}
			var result = await _productService.AddAsync(product);
			return Ok(result);
		}
	}
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
			var result = await _productService.AddAsync(product);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _productService.GetAllAsync();
			return Ok(result);
		}
	}
}

using Business.Abstract;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Business.Features.Products.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator, IProductService productService)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery]GetListProductQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetById([FromQuery] GetByIdProductQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody]CreateProductCommand createProductCommand)
		{
			var result = await _mediator.Send(createProductCommand);
			return Ok(result);	
		}

		[HttpPost]
		public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
		{
			var result = await _mediator.Send(updateProductCommand);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Delete([FromQuery] DeleteProductCommand deleteProductCommand)
		{
			var result = await _mediator.Send(deleteProductCommand);
			return Ok(result);
		}
	}
}

using AutoMapper;
using Business.Abstract;
using Business.Features.Products.Rules;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Products.Commands.Update
{
	public class UpdateProductCommand : IRequest<UpdateProductResponse>
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public double UnitPrice { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
	}


	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		private readonly ProductBusinessRules _productBusinessRules;

		public UpdateProductCommandHandler(IProductService productService, IMapper mapper, ProductBusinessRules productBusinessRules)
		{
			_productService = productService;
			_mapper = mapper;
			_productBusinessRules = productBusinessRules;
		}

		public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			await _productBusinessRules.UpdateProductDuplicateNameCheckAsync(request.Name,request.Id);
			var updatedProduct = await _productService.UpdateAsync(_mapper.Map<Product>(request));
			return _mapper.Map<UpdateProductResponse>(updatedProduct);
		}
	}
}

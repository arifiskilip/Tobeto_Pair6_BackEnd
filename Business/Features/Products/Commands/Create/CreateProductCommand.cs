using AutoMapper;
using Business.Abstract;
using Business.Features.Products.Rules;
using Business.Features.Products.Validations;
using Entities.Concrete;
using FluentValidation;
using MediatR;

namespace Business.Features.Products.Commands.Create
{
	public class CreateProductCommand : IRequest<CreateProductResponse>
	{
		public string Name { get; set; }
		public double UnitPrice { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }



		public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
		{
			private readonly IProductService _productService;
			private readonly IMapper _mapper;
			private readonly ProductBusinessRules _productBusinessRules;

			public CreateProductCommandHandler(IProductService productService, IMapper mapper, ProductBusinessRules productBusinessRules)
			{
				_productService = productService;
				_mapper = mapper;
				_productBusinessRules = productBusinessRules;
			}

			async Task<CreateProductResponse> IRequestHandler<CreateProductCommand, CreateProductResponse>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
			{
				//Rules
				await _productBusinessRules.DuplicateNameCheckAsync(request.Name);

				var addedProduct = await _productService.AddAsync(_mapper.Map<Product>(request));

				return _mapper.Map<CreateProductResponse>(addedProduct); 
			}
		}
	}
}

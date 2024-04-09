using AutoMapper;
using Business.Abstract;
using Business.Features.Products.Rules;
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

			Task<CreateProductResponse> IRequestHandler<CreateProductCommand, CreateProductResponse>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
			{
				throw new NotImplementedException();
			}
		}
	}
}

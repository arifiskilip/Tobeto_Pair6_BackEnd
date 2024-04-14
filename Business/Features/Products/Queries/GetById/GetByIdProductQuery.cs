using AutoMapper;
using Business.Abstract;
using MediatR;

namespace Business.Features.Products.Queries.GetById
{
	public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
	{
		public int Id { get; set; }



		public class GetByIdQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
		{
			private readonly IProductService _productService;
			private readonly IMapper _mapper;

			public GetByIdQueryHandler(IProductService productService, IMapper mapper)
			{
				_productService = productService;
				_mapper = mapper;
			}

			public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
			{
				var result = await _productService.GetByIdAsync(request.Id);
				return _mapper.Map<GetByIdProductResponse>(result);
			}
		}
	}
}

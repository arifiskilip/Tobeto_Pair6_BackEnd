using Business.Abstract;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Business.Features.Products.Queries.GetList
{
	public class GetListProductQuery :IRequest<GetListProductResponse>, ISecuredRequest
	{
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

		public string[] RequiredRoles => ["Admin,Member"];

		public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListProductResponse>
		{
			private readonly IProductService _productService;

			public GetListProductQueryHandler(IProductService productService)
			{
				_productService = productService;
			}

			public async Task<GetListProductResponse> Handle(GetListProductQuery request, CancellationToken cancellationToken)
			{
				var result = await _productService.GetAllAsync(request.PageIndex, request.PageSize);
				return new()
				{
					Datas = result,
				};
			}
		}
	}
}

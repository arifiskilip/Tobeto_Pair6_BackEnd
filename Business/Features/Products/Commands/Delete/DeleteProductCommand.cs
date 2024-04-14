using AutoMapper;
using Business.Abstract;
using MediatR;

namespace Business.Features.Products.Commands.Delete
{
	public class DeleteProductCommand : IRequest<DeleteProductResponse>
	{
        public int Id { get; set; }

		public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
		{
			private readonly IProductService _productService;

			public DeleteProductCommandHandler(IProductService productService, IMapper mapper)
			{
				_productService = productService;
			}

			public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
			{
				await _productService.DeleteAsync(request.Id);
				return new DeleteProductResponse()
				{
					Message = "Silme işlemi başarılı!"
				};
			}
		}
	}
}

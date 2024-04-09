using Entities.Concrete;

namespace Business.Features.Products.Commands.Create
{
	internal class CreateProductResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public double UnitPrice { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

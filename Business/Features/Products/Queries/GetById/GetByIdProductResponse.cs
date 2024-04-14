namespace Business.Features.Products.Queries.GetById
{
	public class GetByIdProductResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public double UnitPrice { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

namespace Business.Dtos.Request.Product
{
	public class UpdateProductRequest
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public double UnitPrice { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
	}
}

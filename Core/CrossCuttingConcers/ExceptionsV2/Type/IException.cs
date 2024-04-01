namespace Core.CrossCuttingConcers.ExceptionsV2.Type
{
	public abstract class IException : Exception
	{
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

		protected IException(int statusCode, string title, string detail) : base(detail)
		{
			StatusCode = statusCode;
			Title = title;
			Detail = detail;
		}
	}
}

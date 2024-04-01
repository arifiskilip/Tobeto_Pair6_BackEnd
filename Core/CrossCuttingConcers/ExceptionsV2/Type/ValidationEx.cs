using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcers.ExceptionsV2.Type
{
	public class ValidationEx : IException
	{
		public ValidationEx(string message) : base(StatusCodes.Status400BadRequest,"Validation Title",message)
		{

		}
  
    }
}

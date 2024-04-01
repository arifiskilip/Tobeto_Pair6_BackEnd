using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcers.ExceptionsV2.Type
{
	public class NatFounEx : IException
	{
		public NatFounEx(string message) : base(StatusCodes.Status404NotFound,"Not found title",message)
		{
		}

    }
}

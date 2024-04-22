using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Features.Auth.Commands.Login
{
	public class LoginResponse
	{
		public User User { get; set; }
		public AccessToken Token { get; set; }
	}
}

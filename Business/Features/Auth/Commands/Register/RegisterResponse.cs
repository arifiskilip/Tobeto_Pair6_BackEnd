using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Features.Auth.Commands.Register
{
	public class RegisterResponse
	{
        public User User { get; set; }
        public AccessToken Token { get; set; }
    }
}

using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
	public interface IAuthService
	{
		Task<bool> UserExistsAsync(string email);
		Task<AccessToken> CreateAccessTokenAsync(User user);
	}
}

using Business.Abstract;
using Core.Entities;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;

namespace Business.Concrete
{
	public class AuthManager : IAuthService
	{
		private readonly IUserDal _userDal;
		private readonly ITokenHelper _tokenHelper;

		public AuthManager(IUserDal userDal, ITokenHelper tokenHelper)
		{
			_userDal = userDal;
			_tokenHelper = tokenHelper;
		}

		public async Task<AccessToken> CreateAccessTokenAsync(User user)
		{
			List<Role> userRoles = await _userDal.GetClaimsAsync(user);
			AccessToken token = _tokenHelper.CreateToken(user, userRoles);
			return token;
		}

		public async Task<bool> UserExistsAsync(string email)
		{
			return await _userDal.AnyAsync(x=> x.Email.ToLower() == email.ToLower());
		}
	}
}

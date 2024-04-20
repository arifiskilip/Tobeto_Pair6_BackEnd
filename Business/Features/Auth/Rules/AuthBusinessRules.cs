using Business.Abstract;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Business.Features.Auth.Rules
{
	public class AuthBusinessRules
	{
		private readonly IAuthService _authService;

		public AuthBusinessRules(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task CheckDuplicateEmailAsync(string email)
		{
			var result = await _authService.UserExistsAsync(email);
			if (result)
			{
				throw new BusinessException("Böyle bir kullanıcı zaten mevcut.");
			}
		}
	}
}

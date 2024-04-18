using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
	public interface IUserService
	{
		Task<User> AddAsync(User user);
		Task DeleteAsync(User user);
		Task<User> UpdateAsync(User user, IFormFile file);
		Task<List<User>> GetAllAsync();
		Task<User> GetByUserIdAsync(int userId);
		List<Role> GetClaims(User user);
		Task<User> GetByMailAsync(string email);
	}
}

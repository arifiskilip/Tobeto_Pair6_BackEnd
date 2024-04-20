using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Abstract
{
	public interface IUserService
	{
		Task<User> AddAsync(User user);
		Task DeleteAsync(User user);
		Task<User> UpdateAsync(User user);
		Task<IPaginatedList<User>> GetAllAsync();
		Task<User> GetByUserIdAsync(int userId);
		Task<List<Role>> GetClaimsAsync(User user);
		Task<User> GetByMailAsync(string email);
	}
}

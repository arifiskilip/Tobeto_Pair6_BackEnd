using Core.DataAccess.Repositories;
using Core.Entities;

namespace DataAccess.Abstract
{
	public interface IUserDal : IRepository<User,int> , IAsyncRepository<User,int>
	{
		Task<List<Role>> GetClaimsAsync(User user);
	}
}

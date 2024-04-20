using Core.DataAccess.Repositories;
using Core.Entities;

namespace DataAccess.Abstract
{
	public interface IUserRoleDal : IRepository<UserRole, int>, IAsyncRepository<UserRole, int>
	{
	}
}

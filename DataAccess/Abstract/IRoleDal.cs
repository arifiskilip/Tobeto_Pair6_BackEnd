using Core.DataAccess.Repositories;
using Core.Entities;

namespace DataAccess.Abstract
{
	public interface IRoleDal : IRepository<Role, int>, IAsyncRepository<Role, int>
	{
	}
}

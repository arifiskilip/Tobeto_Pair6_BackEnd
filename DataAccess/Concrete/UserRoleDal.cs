using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete
{
	public class UserRoleDal : RepositoryBase<UserRole, int, TobetoContext>, IUserRoleDal
	{
		public UserRoleDal(TobetoContext context) : base(context)
		{
		}
	}
}

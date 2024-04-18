using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete
{
	public class UserDal : RepositoryBase<User, int, TobetoContext>, IUserDal
	{
		public UserDal(TobetoContext context) : base(context)
		{
		}
	}
}

using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete
{
	public class RoleDal : RepositoryBase<Role, int, TobetoContext>, IRoleDal
	{
		public RoleDal(TobetoContext context) : base(context)
		{
		}
	}
}

using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;

namespace Business.Concrete
{
	public class UserRoleManager : IUserRoleService
	{
		private readonly IUserRoleDal _userRoleDal;

		public UserRoleManager(IUserRoleDal userRoleDal)
		{
			_userRoleDal = userRoleDal;
		}

		public async Task AddUserRoleAsync(UserRole userRole)
		{
			await _userRoleDal.AddAsync(userRole);
		}
	}
}

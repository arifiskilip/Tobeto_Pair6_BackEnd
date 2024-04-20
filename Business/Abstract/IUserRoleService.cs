using Core.Entities;

namespace Business.Abstract
{
	public interface IUserRoleService
	{
		Task AddUserRoleAsync(UserRole userRole);
	}
}

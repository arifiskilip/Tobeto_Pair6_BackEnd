using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
	public class UserDal : RepositoryBase<User, int, TobetoContext>, IUserDal
	{
		public UserDal(TobetoContext context) : base(context)
		{
		}

		public async Task<List<Role>> GetClaimsAsync(User user)
		{
			//List<Role> roles =await _entity
			//	.Include(x => x.UserRoles)
			//	.ThenInclude(ur => ur.Role)
			//	.SelectMany(x => x.UserRoles.Select(ur => ur.Role))
			//	.Where(role => role.UserRoles.Any(ur => ur.UserId == user.Id))
			//	.Select(role => new Role
			//	  {
			//		  Id = role.Id,
			//		  CreatedDate = role.CreatedDate,
			//		  DeletedDate = role.DeletedDate,
			//		  UpdatedDate = role.UpdatedDate,
			//		  Name = role.Name
			//	  })
			//	  .ToListAsync();
			//return roles;
			var result = from role in _context.Set<Role>()
						 join userRole in _context.Set<UserRole>()
							 on role.Id equals userRole.RoleId
						 where userRole.UserId == user.Id
						 select new Role { Id = role.Id, Name = role.Name };
			return await result.ToListAsync();
		}
	}
}

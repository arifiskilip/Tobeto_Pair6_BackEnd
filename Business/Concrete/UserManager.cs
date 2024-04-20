using Business.Abstract;
using Core.CrossCuttingConcers.Exceptions.Types;
using Core.DataAccess.Paging;
using Core.Entities;
using Core.Entities.Enums;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;
		private readonly IUserRoleService _userRoleService;

		public UserManager(IUserDal userDal, IUserRoleService userRoleService)
		{
			_userDal = userDal;
			_userRoleService = userRoleService;
		}

		public async Task<User> AddAsync(User user)
		{
			await _userDal.AddAsync(user);
			await _userRoleService.AddUserRoleAsync(new()
			{
				CreatedDate = DateTime.Now,
				UserId = user.Id,
				RoleId = (int)RoleEnum.Member,
			});
			return user;
		}

		public async Task DeleteAsync(User user)
		{
			await _userDal.DeleteAsync(user);
		}

		public async Task<IPaginatedList<User>> GetAllAsync()
		{
		    var users = await _userDal.GetListAsync();
			return users;
		}

		public async Task<User> GetByMailAsync(string email)
		{
			var checkUser = await _userDal.GetAsync(x => x.Email.ToLower() == email.ToLower());
			if (checkUser != null)
			{
				return checkUser;
			}
			throw new NotFoundException("Kullanıcı bulunamadı.");
		}

		public async Task<User> GetByUserIdAsync(int userId)
		{
			var checkUser = await _userDal.GetAsync(x => x.Id == userId);
			if (checkUser != null)
			{
				return checkUser;
			}
			throw new NotFoundException("Kullanıcı bulunamadı.");
		}

		public async Task<List<Role>> GetClaimsAsync(User user)
		{
			var userRoles = await _userDal.GetClaimsAsync(user);
			return userRoles;
		}

		public async Task<User> UpdateAsync(User user)
		{
			var updatedUser = await _userDal.UpdateAsync(user);
			return updatedUser;
		}
	}
}

using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public async Task<User> AddAsync(User user)
		{
			await _userDal.AddAsync(user);
			return user;
		}

		public async Task DeleteAsync(User user)
		{
			await _userDal.DeleteAsync(user);
		}

		public async Task<List<User>> GetAllAsync()
		{
		    var users = await _userDal.GetListAsync();
			return null;
		}

		public Task<User> GetByMailAsync(string email)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetByUserIdAsync(int userId)
		{
			throw new NotImplementedException();
		}

		public List<Role> GetClaims(User user)
		{
			throw new NotImplementedException();
		}

		public Task<User> UpdateAsync(User user, IFormFile file)
		{
			throw new NotImplementedException();
		}
	}
}

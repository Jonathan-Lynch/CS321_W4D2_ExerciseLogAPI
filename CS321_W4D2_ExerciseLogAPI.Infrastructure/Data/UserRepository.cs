using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _appDbContext;
		public UserRepository(AppDbContext dbContext)
		{
			_appDbContext = dbContext;
		}

		public User Add(User user)
		{
			_appDbContext.User.Add(user);
			_appDbContext.SaveChanges();
			return user;
		}

		public User Get(int id)
		{
			return _appDbContext.User.Include(u => u.Activities).SingleOrDefault(u => u.Id == id);
		}

		public IEnumerable<User> GetAll()
		{
			return _appDbContext.User.Include(u => u.Activities).ToList();
		}

		public void Remove(User removeUser)
		{
			_appDbContext.User.Remove(removeUser);
			_appDbContext.SaveChanges();
		}

		public User Update(User updatedUser)
		{
			var currentUser = _appDbContext.User.Find(updatedUser);
			if (currentUser == null) return null;
			_appDbContext.Entry(currentUser).CurrentValues.SetValues(updatedUser);
			_appDbContext.User.Update(currentUser);
			_appDbContext.SaveChanges();
			return currentUser;
		}
	}
}

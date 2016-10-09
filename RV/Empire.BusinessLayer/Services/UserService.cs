using System.Linq;
using Empire.DataAccessLayer.Repositories;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.BusinessLayer
{
	public class UserService
	{
		private EmpireContext _context = new EmpireContext();

		private UserRepository _productRepository;
		private UserRepository UserRepository => _productRepository ?? (_productRepository = new UserRepository(_context));

		private static UserService _instance;
		public static UserService Instance => _instance ?? (_instance = new UserService());

		private static User Convert(UserDto item)
		{
			return new User
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Email = item.Email
			};
		}
		private static UserDto Convert(User item)
		{
			return new UserDto
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Email = item.Email
			};
		}

		public UserDto Login(string email, string password)
		{
			return Convert(UserRepository.Get(x => x.Email == email && x.Password == password).FirstOrDefault());
		}
	}
}
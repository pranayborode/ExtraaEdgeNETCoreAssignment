using MobileStoreManager.Data;
using MobileStoreManager.Entities;
using MobileStoreManager.Repository.Interfaces;

namespace MobileStoreManager.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddUser(Users users)
        {
            _context.Users.Add(users);
            int result = _context.SaveChanges();
            return result;
        }

        public int DeleteUser(int userId)
        {
            var user = _context.Users.Where( u => u.UserId == userId).FirstOrDefault();

            int result = 0;

            if (user != null)
            {
                user.IsActive = 0;
                result = _context.SaveChanges();
            }
            return result;
        }

        public Users Login(Users users)
        {
            var _user = _context.Users.Where(u => u.EmailId == users.EmailId && u.Password == users.Password).FirstOrDefault();
                return _user;
        }
    }
}

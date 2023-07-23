using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public class UserRepository : IUserRepository
    {

        private readonly SignInDBContext _context;

        public UserRepository(SignInDBContext context)
        {
            _context = context;
        }

        public Users GetUserByEmailAndPassword(string Email, string Password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
        }
    }

}

using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public interface IUserRepository
    {
        Users GetUserByEmailAndPassword(string email, string password);
    }
}


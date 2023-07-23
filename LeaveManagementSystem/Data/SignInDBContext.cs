using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Data
{
    public class SignInDBContext : DbContext
    {
        public SignInDBContext(DbContextOptions<SignInDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}

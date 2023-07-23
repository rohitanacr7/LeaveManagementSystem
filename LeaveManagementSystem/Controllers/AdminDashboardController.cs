using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeaveManagementSystem.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly UsersDBContext _dbContext;

        public AdminDashboardController(UsersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("AdminDashboard/AddUser")]
        [Route("/AdminDashboard")]
        public IActionResult AddUser()
        {
            var usersViewModel = new UsersViewModels
            {
                ExistingUsers = _dbContext.Users.ToList(),
                NewUser = new Users()
            };

            return View(usersViewModel);
        }


        [HttpPost]
        [Route("AdminDashboard/AddUser")]
        [Route("/AdminDashboard")]
        public IActionResult AddUser(UsersViewModels usersViewModel)
        {
            try
            {
                usersViewModel.NewUser.UserId = Guid.NewGuid().ToString();
                usersViewModel.NewUser.UserType = usersViewModel.usertype;
                usersViewModel.NewUser.CreatedAt = DateTime.Now;
                _dbContext.Users.Add(usersViewModel.NewUser);
                _dbContext.SaveChanges();
                return RedirectToAction("AddUser");
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine($"Database Exception: {ex.Message}");
            }
            usersViewModel.ExistingUsers = _dbContext.Users.ToList();
            return View(usersViewModel);
        }

        [Route("AdminDashboard/Leaves")]
        public IActionResult Leaves()
        {
            return View();
        }

        [Route("AdminDashboard/CreateLeaveType")]
        public IActionResult CreateLeaveType()
        {
            return View();
        }
        [Route("AdminDashboard/DefaultLeaves")]
        public IActionResult DefaultLeaves()
        {
            return View();
        }
    }
}

using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserRepository _userRepository;

        public RegistrationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UsersViewModels usersViewModels)
        {
            string Email = usersViewModels.NewUser.Email;
            string Password = usersViewModels.NewUser.Password;
            var user = _userRepository.GetUserByEmailAndPassword(Email, Password);

            if (user != null)
            {
                if (user.UserType == "Admin")
                {
                    return RedirectToAction("AddUser", "AdminDashboard");
                }
                else if (user.UserType == "Employee")
                {
                    return RedirectToAction("", "EmployeeDashboard");
                }
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View();

        }
    }
}

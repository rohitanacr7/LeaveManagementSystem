using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        [Route("/EmployeeDashboard")]
        [Route("EmployeeDashboard/ApplyLeave")]
        public IActionResult ApplyLeave()
        {
            return View();
        }
        [Route("EmployeeDashboard/DefaultLeaves")]
        public IActionResult DefaultLeaves()
        {
            return View();
        }
        [Route("EmployeeDashboard/Profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}

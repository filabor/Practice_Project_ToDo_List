using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todo_list.Models;
using todo_list.Repository;

namespace todo_list.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserRepository _userRepo;
        TaskRepository _taskRepo;

        public HomeController(ILogger<HomeController> logger)
        {
            _userRepo = new UserRepository();
            _taskRepo = new TaskRepository();
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<TaskToDo> model = _taskRepo.GetTasks();
            return View(model);
        }

        
        public IActionResult UserProfile()
        {
            User model = _userRepo.GetUser();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
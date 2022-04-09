using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list.Repository;
using todo_list.Models;

namespace todo_list.Controllers
{
    public class TaskToDoController : Controller
    {
        TaskRepository _taskRepo;
        UserRepository _userRepo;

        public TaskToDoController()
        {
            _taskRepo = new TaskRepository();
            _userRepo = new UserRepository();
        }

        // GET: TaskToDoController
        public ActionResult Index()
        {
            List<TaskToDo> model = _taskRepo.GetTasks();
            return View(model);
        }

        // GET: TaskToDoController/Details/5
        public ActionResult Details(int id)
        {
            TaskToDo task = _taskRepo.GetTaskById(id);
            return View(task);
        }

        // GET: TaskToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskToDo new_task)
        {
            try
            {
                new_task.TaskID = _taskRepo.GetTasks().Count() > 0 ? _taskRepo.GetTasks().Max(a => a.TaskID) + 1 : 1;
                _taskRepo.CreateNewTask(new_task);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            TaskToDo find_task = _taskRepo.GetTaskById(id);

            if(find_task == null)
            {
                return RedirectToAction("Index");
            }

            return View(find_task);
        }

        // POST: TaskToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                TaskToDo find_task = _taskRepo.GetTaskById(id);
                if(find_task == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _taskRepo.UpdateSelectedTask(find_task, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            TaskToDo find_task = _taskRepo.GetTaskById(id);
            return View(find_task);
        }

        // POST: TaskToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _taskRepo.DeleteTask(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

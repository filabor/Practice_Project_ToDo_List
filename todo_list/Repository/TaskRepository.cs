using todo_list.Models;

namespace todo_list.Repository
{
    public class TaskRepository
    {
        private static List<TaskToDo> tasks;
        UserRepository _userRepo;

        public TaskRepository()
        {
            _userRepo = new UserRepository();
            if(tasks == null)
            {
                tasks = new List<TaskToDo>();
                TaskData();
            }
        }

        public List<TaskToDo> GetTasks()
        {
            return tasks;
        }

        public TaskToDo GetTaskById(int id)
        {
            var find_task = (
                from task in tasks
                where task.TaskID == id
                select task
            ).SingleOrDefault();
            return find_task;
        }

        public void CreateNewTask(TaskToDo new_task)
        {
            tasks.Add(new_task);
        }

        public void UpdateSelectedTask(TaskToDo update_task, IFormCollection new_data)
        {
            update_task.TaskName = new_data["TaskName"];
            update_task.DateOfTask = DateTime.Parse(new_data["DateOfTask"]);
            update_task.Description = new_data["Descripton"];
            update_task.Place = new_data["Place"];
        }

        public void DeleteTask(int id)
        {
            tasks.Remove(GetTaskById(id));
        }

        public void TaskData()
        {
            TaskToDo task1 = new TaskToDo()
            {
                TaskID = 1,
                TaskName = "Dovršiti prezentaciju za sastanak, do 10:00!",
                DateOfTask = new DateTime(2022, 05, 22),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Ured",
                User = _userRepo.GetUser()
            };
            TaskToDo task2 = new TaskToDo()
            {
                TaskID = 2,
                TaskName = "Sastanka u s klijentom u 11:00!",
                DateOfTask = new DateTime(2022, 04, 7),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Dvorana za sastanke",
                User = _userRepo.GetUser()
            };
            TaskToDo task3 = new TaskToDo()
            {
                TaskID = 3,
                TaskName = "Sastanak s kolegama, 8:00!",
                DateOfTask = new DateTime(2022, 04, 4),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Dvorana za sastanke",
                User = _userRepo.GetUser()
            };
            TaskToDo task4 = new TaskToDo()
            {
                TaskID = 4,
                TaskName = "Rad na projektu od 9:00 - 16:00!",
                DateOfTask = new DateTime(2022, 04, 9),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Ured",
                User = _userRepo.GetUser()
            };
            TaskToDo task5 = new TaskToDo()
            {
                TaskID = 5,
                TaskName = "Putovanje u Francusku!",
                DateOfTask = new DateTime(2022, 04, 10),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Aerodrom",
                User = _userRepo.GetUser()
            };
            TaskToDo task6 = new TaskToDo()
            {
                TaskID = 5,
                TaskName = "Održati prezentaciju na konferenciji!",
                DateOfTask = new DateTime(2022, 04, 8),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book..",
                Place = "Konferencijska dvorana hotela",
                User = _userRepo.GetUser()
            };

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);
            tasks.Add(task6);
        }
    }
}

namespace todo_list.Models
{
    public class TaskToDo
    {

        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DateOfTask { get; set; }
        public string Description { get; set; }
        public string Place  { get; set; }
        public User User { get; set; }
    }
}

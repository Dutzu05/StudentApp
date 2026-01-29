namespace StudentTaskManager.Models
{
    public class Student
    {
        public string Name { get; set; }
        public List<TaskItem> Tasks { get; set; } = new();
    }
}

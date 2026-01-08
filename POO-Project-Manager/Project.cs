public class Project
{
    public List<TaskItem> Tasks {get; set;} = new();
    public void AddTask(TaskItem task)
    {
        Tasks.Add(task);
    }
}
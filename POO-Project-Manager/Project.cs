using System.Collections.Generic;
public class Project
{
    public string Name {get; set;}
    public List<TaskItem> Tasks {get; } = new();
    public Project(string name)
    {
        Name=name;
    }
    public void AddTask(TaskItem task)
    {
        Tasks.Add(task);
    }
    public override string ToString()
    {
        return $"{Name}, ({Tasks.Count} tasks)";
    }
}
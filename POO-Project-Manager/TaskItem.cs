public enum TaskStatus
{
    ToDo,
    InProgress,
    Done

}
public class TaskItem
{
    public int Id {get; set;}
    public string Title{get; set;}
    public TaskStatus Status{get; set;}
    public string AssignedTo {get; set;}
    public TaskItem(int id, string title)
    {
        Id=id;
        Title=title;
        Status=TaskStatus.ToDo;
        AssignedTo="";
    }

    public override string ToString()
    {
        return $"Task {Id}: {Title} - {Status}";
    }
}
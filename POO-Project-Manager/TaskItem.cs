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
    public TaskItem(int id, string title)
    {
        Id=id;
        Title=titlu;
        Status=TaskStatus.ToDo;
    }
}
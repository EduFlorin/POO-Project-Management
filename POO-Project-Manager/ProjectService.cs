namespace POO_Project_Manager;

public class ProjectService
{
    private List<Project> projects;

    public ProjectService(List<Project> projectList)
    {
        projects = projectList;
    }

    public void CreateProject(string name)
    {
        projects.Add(new Project(name));
        Console.WriteLine($"Proiect creat: {name}");
    }

    public void AddTask(int projectIndex, TaskItem task)
    {
        if (projectIndex < 0 || projectIndex >= projects.Count)
        {
            Console.WriteLine("Index proiect invalid!");
            return;
        }
        projects[projectIndex].AddTask(task);
        Console.WriteLine($"Task adaugat: {task.Title}");
    }
    public void ShowProjects()
    {
        for (int i = 0; i < projects.Count; i++)
        {
            Console.WriteLine($"{i}. {projects[i]}");
            foreach (var task in projects[i].Tasks)
            {
                Console.WriteLine($" - {task} (Asignat: {task.AssignedTo})");
            }
        }
    }

}
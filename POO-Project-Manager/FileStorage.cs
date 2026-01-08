using System.IO;
using System.Text.Json;
public class FileStorage
{
    private const string FileName="project.json";
    public void Save(Project project)
    {
        string json=JsonSerializer.Serialize(project);
        File.WriteAllText(FileName, json);
    }
    public Project Load()
    {
        if (!File.Exists(FileName))
        {
            return new Project();
        }
        try 
        {
            string json=File.ReadAllText(FileName);
            Project project=JsonSerializer.Deserialize<Project>(json); 
            return project ?? new Project();
        }
        catch
        {
            return new Project();
        }
    }
}
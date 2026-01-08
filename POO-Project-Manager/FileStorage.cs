using System.IO;
using System.text.json;
public class FileStorage
{
    private const string FileName="project.json";
    public void Save(Project project)
    {
        string json=JsonSerializer.Srrialize(project);
        File.WriteAllText(FileName, json);
    }
    public Project Load()
    {
        if(!FileName.Exists(FileName))
        {
            return new Project();
        }
        try 
        {
            string json=FileName.ReadAllText(FileName);
            Project project=JsonSerializer.Deserialize<Project>(json); 
            return project ?? new Project();
        }
        catch
        {
            return new Project();
        }
    }
}
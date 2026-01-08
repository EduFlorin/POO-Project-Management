using System.IO;
using System.Text.Json;
using System.Collections.Generic;
public class FileStorage
{
    private const string ProjectFile="projects.json";
    private const string UserFile="users.json";
    public void SaveProjects(List<Project> projects)
    {
        string json=JsonSerializer.Serialize(projects);
        File.WriteAllText(ProjectFile, json);
    }
    public List<Project> LoadProjects()
    {
        if (!File.Exists(ProjectFile))
        {
            return new List<Project>();
        }
        try 
        {
            string json=File.ReadAllText(ProjectFile);
            List<Project> project=JsonSerializer.Deserialize<List<Project>>(json); 
            return project ?? new List<Project>();
        }
        catch
        {
            return new List<Project>();
        }
    }
    public void SaveUsers(List<User> users)
    {
       string json=JsonSerializer.Serialize(users);
       File.WriteAllText(UserFile, json); 
    }
    public List<User> LoadUsers()
    {
        if (!File.Exists(UserFile))
        {
            return new List<User>();
        }
        try 
        {
            string json=File.ReadAllText(UserFile);
            List<User> user=JsonSerializer.Deserialize<List<User>>(json); 
            return user ?? new List<User>();
        }
        catch
        {
            return new List<User>();
        }
    }
}
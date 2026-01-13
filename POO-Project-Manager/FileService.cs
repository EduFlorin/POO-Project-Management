namespace POO_Project_Manager;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
public class FileService
{ public static void SaveProjects(List<Project> projects, string fileName)
    {
        try
        {
            string json=JsonSerializer.Serialize(projects);
            File.WriteAllText(fileName, json);
        }
        catch
        {
            Console.WriteLine("Eroare la salvarea proiectelor!");
        }
    }
    public static List<Project> LoadProjects(string fileName)
    {
        try
        {
            if (!File.Exists(fileName))
                return new List<Project>();
            string json= File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Project>>(json) ?? new List<Project>();
        }
        catch
        {
            Console.WriteLine("Eroare la incarcarea proiectelor!");
            return new List<Project>();
        }
        
    }
}

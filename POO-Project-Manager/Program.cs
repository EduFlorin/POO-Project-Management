using POO_Project_Manager;

class Program
{
    List<User> users = new();
    List<Project> projects = new();
    AuthenticationService authService;
    ProjectService projectService;

    public void Run()
    {
        projects = FileService.LoadProjects("projects.json");
        Console.Write("Numar angajati: ");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nAngajatul {i + 1}");

            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            Console.Write("Rol (1-Manager, 2-Member): ");
            string role = Console.ReadLine()!;

            if (role == "1")
                users.Add(new Manager(username, password));
            else
                users.Add(new Member(username, password));
        }

        authService = new AuthenticationService(users);
        projectService = new ProjectService(projects);

        // --- Login ---
        Console.Write("\nUsername login: ");
        string loginUser = Console.ReadLine()!;
        Console.Write("Password login: ");
        string loginPass = Console.ReadLine()!;

        var loggedUser = authService.Login(loginUser, loginPass);
        if (loggedUser == null)
        {
            Console.WriteLine("Autentificare eșuată!");
            return;
        }

        Console.WriteLine($"Bine ai venit, {loggedUser.Username}!");

        if (loggedUser.Role == UserRole.Manager)
            ManagerMenu();
        else
            MemberMenu(loggedUser.Username);

        // Salvare proiecte
        FileService.SaveProjects(projects, "projects.json");
    }

    void ManagerMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Creează proiect  2. Adaugă task  3. Vezi proiecte  0. Ieșire");
            string opt = Console.ReadLine()!;

            if (opt == "0") break;

            if (opt == "1")
            {
                Console.Write("Nume proiect: ");
                projectService.CreateProject(Console.ReadLine()!);
            }
            else if (opt == "2")
            {
                Console.Write("Index proiect: ");
                int i = int.Parse(Console.ReadLine()!);

                Console.Write("Id task: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write("Titlu task: ");
                string t = Console.ReadLine()!;

                Console.Write("Asignare la (username): ");
                string a = Console.ReadLine()!;

                projectService.AddTask(i, new TaskItem(id, t) { AssignedTo = a });
            }
            else if (opt == "3")
            {
                projectService.ShowProjects();
            }
            else
            {
                Console.WriteLine("Opțiune invalidă!");
            }
        }
    }

    void MemberMenu(string username)
    {
        Console.WriteLine("\nTaskurile tale:");
        foreach (var p in projects)
        {
            foreach (var t in p.Tasks)
            {
                if (t.AssignedTo == username)
                {
                    Console.WriteLine($"{p.Name} - {t.Title} [{t.Status}]");
                }
            }
        }
    }

    static void Main()
    {
        new Program().Run();
    }
}

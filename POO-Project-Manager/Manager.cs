namespace POO_Project_Manager;

public class Manager : User
{
    public Manager(string username, string password)
        : base(username, password, UserRole.Manager) { }
}
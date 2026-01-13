namespace POO_Project_Manager;

public class AuthenticationService
{
    private List<User> users;

    public AuthenticationService(List<User> userList)
    {
        users = userList;
    }

    public User Login(string username, string password)
    {
        foreach (var user in users)
        {
            if (user.Username == username && user.Password == password)
                return user;
        }
        Console.WriteLine("Autentificare esuata! Username sau parola incorecta");
        return null;
    }
}
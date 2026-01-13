public enum UserRole
{
    Manager,
    Member
}
public abstract class User
{
    public string Username {get; set;}
    public string Password {get; set;}
    public UserRole Role {get; set;}
    protected User(string username, string password, UserRole role)
    {
        Username=username;
        Password=password;
        Role=role;
    }

    public override string ToString()
    {
        return $"User: {Username}, Role: {Role}";
    }
}
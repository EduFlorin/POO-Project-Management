namespace POO_Project_Manager;

public class Member: User
{
    public Member(string username, string password)
        :base(username, password, UserRole.Member){ }
}
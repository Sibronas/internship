using Internship.Data;

namespace Internship.Business;

public interface ILoginService
{
    void Login(string userName);
    string GetCurrentUser();
}

public class LoginService : ILoginService
{
    private string _currentUser;

    public void Login(string userName) => _currentUser = userName;

    public string GetCurrentUser() => _currentUser;
}
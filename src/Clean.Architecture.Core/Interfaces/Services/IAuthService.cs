namespace Clean.Architecture.Core.Interfaces.Services;

public interface IAuthService
{
    void Login(string username, string password);
    void Logout();
    bool IsAuthenticated(string username);
}
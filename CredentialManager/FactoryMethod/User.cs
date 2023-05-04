using CredentialManager.FactoryMethod;

namespace CredentialManager;

public class User : IUser
{
    private string _username;
    private string _password;

    public User(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public string GetPassword() => _password;

    public string GetUsername() => _username;
}


namespace WebApi
{
    public interface IJwtAuthenticationManager
    {
        string Login(string username, string password);

    }
}

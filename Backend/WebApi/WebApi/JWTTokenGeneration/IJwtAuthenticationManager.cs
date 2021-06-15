namespace WebApi
{
    public interface IJwtAuthenticationManager
    {
        public string Login(string username, string password);

        public string GenerateJWTToken(string username, string password);

    }
}

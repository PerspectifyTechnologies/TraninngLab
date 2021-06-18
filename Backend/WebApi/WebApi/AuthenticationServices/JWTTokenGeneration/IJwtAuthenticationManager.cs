namespace WebApi
{
    public interface IJwtAuthenticationManager
    {
        public string GenerateTokenIfValid(string username, string password,int refresh);

        public string GenerateJWTToken(string username, string password, int refresh);

    }
}

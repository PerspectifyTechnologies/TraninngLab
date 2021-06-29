namespace WebApi.AuthServices.Models
{
    public class RefreshTokenModel
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public System.DateTime ExpirationTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApi.DatabaseServices
{
    public class LogoutModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
    }
}

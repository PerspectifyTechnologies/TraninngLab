using System.ComponentModel.DataAnnotations;

namespace WebApi.DatabaseServices
{
    public class RegisterModel
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

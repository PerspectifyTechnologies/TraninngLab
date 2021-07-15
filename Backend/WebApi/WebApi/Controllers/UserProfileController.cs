using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.UserServices;

namespace WebApi.Controllers
{
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        [EnableCors("ReactPolicy")]
        public class UserProfileController : Controller
    {
        [HttpGet("{username}")]
        public string GetUserDetails(string username)
            {
              return JsonConvert.SerializeObject(UserDetails.Instance.Get(username));
            }
        }
}

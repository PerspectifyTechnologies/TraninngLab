using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

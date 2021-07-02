using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TestServices;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    [Authorize]
    public class TestController : Controller
    {
        [HttpGet("{id}")]
        public async Task<string> GetQnA(int TestID)
        {
            return JsonConvert.SerializeObject(await QnA.Instance.GetRandomTen(TestID));
        }
    }
}

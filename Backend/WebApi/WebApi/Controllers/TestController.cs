using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public IDictionary<int,QnA> GetQnA(int TestID)
        {
            return new GetQnA().GetRandomTen(TestID);
        }
    }
}

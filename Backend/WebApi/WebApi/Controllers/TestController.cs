using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TestServices;
using WebApi.TestServices.Model;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("ReactPolicy")]
    public class TestController : Controller
    {
        public string Get()
        {
            return "huhuh";
        }
        [HttpGet("{id:int}")]
        public string GetQnA(int id)
        {
            return JsonConvert.SerializeObject( QnA.Instance.GetRandomTen(id));
        }
        [HttpPost("{id1:int}/{id2:int}/update")]
        public void SetScore(int id1,int id2, [FromBody] ScoreModel score)
        {
            ScoreCalc.Instance.updateScore(id1,id2,score);
        }
        [HttpGet("courseid/{id:int}")]
        public string GetLevelInfo(int id)
        {
            return JsonConvert.SerializeObject(LevelDetails.Instance.getLevelInfo(id));
        }
    }
}

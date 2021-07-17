using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.TestServices;
using WebApi.TestServices.Model;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost("{courseid:int}/{levelid:int}/update")]
        public void SetScore(int courseid,int levelid, [FromBody] ScoreModel score)
        {
            ScoreCalc.Instance.UpdateScore(courseid,levelid,score);
        }
        [HttpGet("courseid/{id:int}")]
        public string GetLevelInfo(int id)
        {
            return JsonConvert.SerializeObject(LevelDetails.Instance.GetLevelInfo(id));
        }
    }
}

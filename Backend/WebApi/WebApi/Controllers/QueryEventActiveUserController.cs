using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.EventServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryEventActiveUserController : ControllerBase
    {
        public List<EventActiveUser> GetAllEventActiveUsers()
        {


            return EventActiveUserRetrieval.getInstance().getAllEventActiveUsers();

        }
        [HttpGet]
        [Route("EventActiveUserByID")]
        public EventActiveUser GetEventByID([FromQuery] string EventID)
        {
            return EventActiveUserRetrieval.getInstance().GetEventFromID(EventID);
        }
        [Route("LogUserToEvent")]
        public void LogUserToEvent([FromBody] EventActiveUser User)
        {
            EventActiveUserRetrieval.getInstance().Add(User);
            
        }
        [Route("LogUserOffEvent")]
        public void LogUserOffEvent([FromBody] String User, String eventID)
        {
            EventActiveUserRetrieval.getInstance().Remove(User,eventID);

        }
    }
}
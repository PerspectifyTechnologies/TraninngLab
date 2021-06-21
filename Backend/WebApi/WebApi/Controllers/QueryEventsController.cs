using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.EventServices;
using WebApi.CourseServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryEventsController : ControllerBase
    {
        public List<Event> GetEvents()
        {


            return RetrieveEvents.getInstance().getAllEvents();

        }
        [HttpGet]
        [Route("EventByID")]
        public Event GetEventByID([FromQuery] string EventID)
        {
            return RetrieveEvents.getInstance().GetEventFromID(EventID);
        }
    }
}
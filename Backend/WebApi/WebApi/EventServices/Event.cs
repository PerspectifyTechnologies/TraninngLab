using System;
namespace WebApi.EventServices
{
    public class Event
    {
        String eventID;
        public String EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        String url;
        public String Url
        {
            get { return url; }
            set { url = value; }
        }
        Boolean active;
        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }
        public Event()
        {
            startTime = new DateTime();
            endTime = new DateTime();
            active = false;

        }
    }
}

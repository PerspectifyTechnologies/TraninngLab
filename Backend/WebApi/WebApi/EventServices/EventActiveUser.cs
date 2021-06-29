using System;
namespace WebApi.EventServices
{
    public class EventActiveUser
    {
        String userName;
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        String eventID;
        public String EventID
        {
            get { return eventID; }
            set { EventID = value; }
        }
        Boolean panelist;
        public Boolean Panelist
        {
            get { return panelist; }
            set { panelist = value; }

        }
        Boolean active;
        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}

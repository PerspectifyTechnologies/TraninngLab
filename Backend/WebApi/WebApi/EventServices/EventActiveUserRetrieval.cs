using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WebApi.EventServices
{
    public class EventActiveUserRetrieval

    {
        List<EventActiveUser> EventActiveUserList;

        static EventActiveUserRetrieval EventActiveUserRetrievalObject = null;
        



        private EventActiveUserRetrieval()
        {
            EventActiveUserList = new List<EventActiveUser>();


            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try
            {
               
                con.Open();
                string query = "SELECT * from EventActiveUser where Active=1;";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                EventActiveUser currentObj = new EventActiveUser();
                                currentObj.UserName = rdr.GetString(0);
                                currentObj.EventID = rdr.GetString(1);
                                currentObj.Panelist = rdr.GetBoolean(2);
                                currentObj.Active = rdr.GetBoolean(3);
                                EventActiveUserList.Add(currentObj);
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public static EventActiveUserRetrieval getInstance()
        {

            EventActiveUserRetrievalObject = new EventActiveUserRetrieval();
            return EventActiveUserRetrievalObject;

        }


        public void Add(EventActiveUser eventActiveUserObj)
        {
            EventActiveUserList.Add(eventActiveUserObj);


            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try
            {

                int activeParameter = eventActiveUserObj.Active ? 1 : 0;
                int panelistParameter = eventActiveUserObj.Panelist ? 1 : 0;

                con.Open();
                string query = "Insert INTO EventActiveUser VALUES(\"" + eventActiveUserObj.UserName + "\",\"" + eventActiveUserObj.EventID + "\"," + panelistParameter + "," + activeParameter + ");";

                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();



                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        public int Remove(String userName, String eventID )
        {
            for (int i = 0; i < EventActiveUserList.Count; i++)
            {
                EventActiveUser UserAtIndex = EventActiveUserList.ElementAt(i);
                if ((UserAtIndex.UserName.Equals(userName)) && (UserAtIndex.EventID.Equals(eventID)))
                {
                    EventActiveUserList.RemoveAt(i);


                    

                    MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM EventActiveUser WHERE userName=\"" + UserAtIndex.UserName + "\" AND EventID=\""+UserAtIndex.EventID+"\" ;";
                        MySqlCommand command = new MySqlCommand(query, con);

                        MySqlDataReader reader = command.ExecuteReader();
                        con.Close();
                        return 1;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

            }
            return 0;
        }


        public List<EventActiveUser> getAllEventActiveUsers()
        {

            return EventActiveUserList;
        }


        public EventActiveUser GetEventFromID(String EventID)
        {
            for (int i = 0; i < EventActiveUserList.Count; i++)
            {
                EventActiveUser EventAtIndex = EventActiveUserList.ElementAt(i);
                if (EventAtIndex.EventID.Equals(EventID))
                {
                    return EventAtIndex;
                }
            }
            return null;
        }

        
    }
}



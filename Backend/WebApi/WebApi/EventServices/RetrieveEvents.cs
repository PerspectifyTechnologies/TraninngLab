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
    public class RetrieveEvents

    {
        List<Event> activeEventList;

        static RetrieveEvents retrieveEventsObject = null;

       
            

        private RetrieveEvents()
        {
            activeEventList = new List<Event>();
            

            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try
            {
                DateTime currentTime = new DateTime();
                currentTime = DateTime.Now;
                
                con.Open();
                string query = "SELECT * from EventList where ((Active=1) && (\'"+ currentTime.ToString("yyyy-MM-dd HH:mm:ss")+"\' BETWEEN StartTime AND EndTime)); ";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Event currentEvent = new Event();
                                currentEvent.Name = rdr.GetString(1);
                                currentEvent.EventID = rdr.GetString(0);
                                currentEvent.StartTime = rdr.GetDateTime(2);
                                currentEvent.Active = rdr.GetBoolean(3);
                                currentEvent.Url = rdr.GetString(4);
                                currentEvent.EndTime = rdr.GetDateTime(5);
                                activeEventList.Add(currentEvent);
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

        public static RetrieveEvents getInstance()
        {

            retrieveEventsObject = new RetrieveEvents();
            return retrieveEventsObject;

        }


        public void Add(Event eventObj)
        {
            activeEventList.Add(eventObj);
            

            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try
            {

                int activeParameter = eventObj.Active ? 1 : 0;
                con.Open();
                string query = "Insert INTO EventList VALUES(\"" + eventObj.EventID + "\",\""+eventObj.Name+"\",\'"+eventObj.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "\',"+activeParameter+",\""+eventObj.Url+ "\",\'" + eventObj.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "\');";

                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();



                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        //public int Remove(int CourseID)
        //{
        //    for (int i = 0; i < activeEventList.Count; i++)
        //    {
        //        Course courseAtIndex = activeEventList.ElementAt(i);
        //        if (courseAtIndex.CourseID.Equals(CourseID))
        //        {
        //            activeEventList.RemoveAt(i);


        //            String cs = "Data Source=/Users/abii/Projects/Bank/Bank/bankDatabase.db; Version=3;";

        //            MySqlConnection con = new MySqlConnection(cs);
        //            try
        //            {
        //                con.Open();
        //                string query = "DELETE FROM CourseDetails WHERE CourseID=" + courseAtIndex.CourseID + ";";
        //                MySqlCommand command = new MySqlCommand(query, con);

        //                MySqlDataReader reader = command.ExecuteReader();
        //                con.Close();
        //                return 1;
        //            }
        //            catch (Exception e)
        //            {
        //                Debug.WriteLine(e.ToString());
        //            }
        //        }

        //    }
        //    return 0;
        //}


        public List<Event> getAllEvents()
        {

            return activeEventList;
        }
        public Event GetEventFromID(String EventID)
        {
            for (int i = 0; i < activeEventList.Count; i++)
            {
                Event EventAtIndex = activeEventList.ElementAt(i);
                if (EventAtIndex.EventID.Equals(EventID))
                {
                    return EventAtIndex;
                }
            }
            return null;
        }

        //public int UpdateUser(User user)
        //{
        //    for (int i = 0; i < userList.Count; i++)
        //    {
        //        User userAtIndex = userList.ElementAt(i);
        //        if (userAtIndex.AccNo.Equals(user.AccNo))
        //        {
        //            userList[i] = user;

        //            String cs = "Data Source=/Users/abii/Projects/Bank/Bank/bankDatabase.db; Version=3;";

        //            SQLiteConnection con = new SQLiteConnection(cs);
        //            con.Open();
        //            string query = "UPDATE BankAcc SET Name=\"" + user.Name + "\", AccNo=" + user.AccNo + ", Balance=" + user.Bal + " WHERE AccNo=" + user.AccNo + ";";
        //            SQLiteCommand command = new SQLiteCommand(con);

        //            command.CommandText = query;

        //            command.ExecuteNonQuery();
        //            con.Close();

        //            return 1;
        //        }

        //    }

        //    return 0;
        //}
    }
}



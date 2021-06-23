using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using WebApplication3;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\richa\\source\\repos\\WebApplication3\\test.db");


        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        [Route("auth")]
        public IEnumerable<string> GetData([FromQuery] string email, [FromQuery] string password)
        {
            SQLiteCommand cmd = new SQLiteCommand(con);
            con.Open();
            string newpass = Crypto.Encryptor.Encrypt(password);
            cmd.CommandText = "SELECT * FROM Student where email='" + email + "' and password ='" + newpass + "'";
            SQLiteDataReader dr = cmd.ExecuteReader();
            List<string> studentData = new List<string>();
            int a = dr.FieldCount;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                  //  studentData.Add("Id: " + dr["id"].ToString());
                    studentData.Add("Name: " + dr["name"].ToString());
                    studentData.Add("email: " + dr["email"].ToString());
                  //  studentData.Add("contact: " + dr["contact"].ToString());
                  //  studentData.Add("address: " + dr["address"].ToString());
                    studentData.Add("password: " + Crypto.Encryptor.Decrypt(dr["password"].ToString()));

                }
            }
            dr.Close();
            con.Close();
            return studentData;
        }



        // for signup
        [HttpPost]
        [Route("signup")]
        public IActionResult Create([FromBody] User Student)
        {
            SQLiteCommand cmd = new SQLiteCommand(con);
            con.Open();
            cmd.CommandText = "INSERT INTO Student(name,email,password) VALUES('" + Student.name + "','" + Student.email + "','"+ Crypto.Encryptor.Encrypt(Student.password)+"')";
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return CreatedAtAction(nameof(Create), Student);

        }


        [HttpPost]
        [Route("login")]
        public IActionResult Signin([FromBody] User Student)
        {
            SQLiteCommand cmd = new SQLiteCommand(con);
            con.Open();
            string newpass = Crypto.Encryptor.Encrypt(Student.password);
            cmd.CommandText = "SELECT FROM Student WHERE EMAIL ='" + Student.email + "' AND password='" + newpass+ "'";
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return CreatedAtAction(nameof(Signin), Student);
        }

      
    }
}
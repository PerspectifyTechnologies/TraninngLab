using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using WebApi.RefreshTokenGeneration;

namespace WebApi.Controllers
{
    public class RefreshJWTTokenIfValid : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public RefreshJWTTokenIfValid(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public IActionResult RefreshTokenIfValid(TokenValidationBody refreshToken)
        {
            try
            {
                FromJWTToken fromJWTToken = new FromJWTToken();
                var Principle = fromJWTToken.ValidateAndGetClaims(refreshToken.Token);//check validity of the JWT token and retrieve claims

                if (Principle != null)
                {
                    var username = Principle.Identity.Name;
                    var password = Principle.Claims.FirstOrDefault(x => x.Type.ToString().Equals("USERSECRET", StringComparison.InvariantCultureIgnoreCase)).Value;

                    RefreshTokenInDB refreshTokenInDB = new RefreshTokenInDB();
                    DateFormat dateFormat= new DateFormat();

                    Tuple<string, string> Refreshtoken = refreshTokenInDB.Check(username);//Check DB if Refresh Token entry is populated
                    if (Refreshtoken is null)
                    {
                        throw new Exception(message: "No Refresh Token for The User");
                    }
                    DateTime expiryDate = dateFormat.ConvertToSTDDateTime(Refreshtoken.Item2);//diff time format in DB and BackEnd
                    string token = "";

                    TimeSpan ts = DateTime.Now - expiryDate;
                    if (ts.TotalSeconds <= 30)//Refresh Token Validity is 6 hours NEED TO CONFIGURE(for testing 30 secs)
                    {
                        token = jwtAuthenticationManager.GenerateTokenIfValid(username, password);//Generate new Jwt Token
                        new GenerateRefreshToken(username);//Store new Refresh Token With New Validity
                    }
                    else
                    {
                        return Unauthorized(new { Status = "error", message = "Refresh Token Expired" });
                    }
                    BlackListToken(refreshToken.Token);
                    return Ok(new { Status = "Success", passwordsa = password, adasdasd = token });

                }
                else
                {
                    return Unauthorized(new { Status = "Error", Message = "JWT token expired" });
                }
            }
            catch (Exception e)
            {
                return Unauthorized(new { Status = "Error", Message = e.Message });
            }
        }
        private void BlackListToken( string token)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "insert into BlackListTokens(token,entrytime) values('" + token + "',now());";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

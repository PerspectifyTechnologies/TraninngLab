using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApi
{
    public class GenerateRefreshToken
    {
        public GenerateRefreshToken(string username)
        {
            RefreshTokenModel refreshTokenEntry = new RefreshTokenModel()
            {
                Username = username,
                RefreshToken = GetRandomRefreshToken(),
                ExpirationTime = DateTime.UtcNow.AddHours(6) // Make this configurable
            };
            StoreRefreshToken(refreshTokenEntry);
        }

        private void StoreRefreshToken(RefreshTokenModel refreshTokenEntry)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; " +
                                                              "userid = root; " +
                                                              "password = Abhi@1214; " +
                                                              "database = training_lab"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO user_refresh_token(email,refreshtoken,expirationdate) VALUES((SELECT email FROM users_info WHERE username = '" + 
                        refreshTokenEntry.Username + "'),'" +
                        refreshTokenEntry.RefreshToken + "','"+
                        refreshTokenEntry.ExpirationTime.ToString("yyyy-MM-dd H:mm:ss") + "');";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        private string GetRandomRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

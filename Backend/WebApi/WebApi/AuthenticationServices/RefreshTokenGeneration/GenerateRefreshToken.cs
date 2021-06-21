using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;

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
                ExpirationTime = DateTime.Now // creation time of the token
            };
            StoreRefreshToken(refreshTokenEntry);
        }

        private void StoreRefreshToken(RefreshTokenModel refreshTokenEntry)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    DeleteOldRefreshToken(conn,refreshTokenEntry.Username);
                    string query = "INSERT INTO RefreshTokens(username,refreshtoken,expirationdate) VALUES('" + 
                        refreshTokenEntry.Username + "','" +
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

        private void DeleteOldRefreshToken(MySqlConnection conn,string username)
        {
            try
            {
                string query = "delete from testinglab.refreshtokens where username ='" + username + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception)
            {
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

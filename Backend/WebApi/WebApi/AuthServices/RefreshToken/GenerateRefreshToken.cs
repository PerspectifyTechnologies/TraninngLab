﻿using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using WebApi.AuthServices.Models;

namespace WebApi.RefreshToken
{
    public class GenerateRefreshToken
    {
        private static Lazy<GenerateRefreshToken> Initializer = new Lazy<GenerateRefreshToken>(() => new GenerateRefreshToken());
        public static GenerateRefreshToken Instance => Initializer.Value;
        private GenerateRefreshToken()
        {
        }
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
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    DeleteOldRefreshToken(conn,refreshTokenEntry.Username);
                    string query = "INSERT INTO refreshtokens VALUES('" + 
                         refreshTokenEntry.Username + "', '" + 
                         refreshTokenEntry.RefreshToken + "', '"+
                         refreshTokenEntry.ExpirationTime.ToString("yyyy-MM-dd H:mm:ss") + "');";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void DeleteOldRefreshToken(MySqlConnection conn,string username)
        {
            try
            {
                string query = "delete from refreshtokens where username ='" + username + "';";
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

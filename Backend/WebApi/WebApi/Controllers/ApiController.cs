﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebApi.AuthenticationServices.CheckSession;
using WebApi.DatabaseServices;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    [Authorize]
    public class ApiController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freez", "Brac", "Chi", "Co", "Mi", "Wa", "Bal", "Ht", "Sweering", "Scohing"
        };
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public ApiController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Employee> Get()
        {
            var rng = new Random();
            List<Employee> employee = new List<Employee>();
            employee.Add(new Employee
            {
                ID = rng.Next(-20, 55),
                Name = Summaries[rng.Next(Summaries.Length)]
            });
            employee.Add(new Employee
            {
                ID = rng.Next(-20, 55),
                Name = Summaries[rng.Next(Summaries.Length)]
            });
            employee.Add(new Employee
            {
                ID = rng.Next(-20, 55),
                Name = Summaries[rng.Next(Summaries.Length)]
            });
            return employee;
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult GetAuth([FromBody]CurrentSession currentSession)//All not Done
        {
            CheckBlacklist checkBlacklist = new CheckBlacklist();
            if (checkBlacklist.IfPresent(HttpContext.Request.Headers["Authorization"].ToString().Substring(7)))
                return StatusCode(StatusCodes.Status400BadRequest,
                 new { Status = "Error", Message = "Token Invalid. Login Again or use another token" });
            return Ok(new { Status = "Success", OnlyAuthorizedMembers = "will see this message" });
        }


        [AllowAnonymous]
        [HttpPost("login")]//All not Done
        public IActionResult Login([FromBody] LoginModel userCred)
        {
            string mess = "";
            //check if the refresh token is expired, then continue, else land user in login page
            //WE CAN ADD THIS CODE IN OTHER FUNCTION FOR A FEATURE WHERE A USER CLICKS ON HOME LINK, MAIN URL, IF REFRESH TOKEN VALID, AUTHENTICATE WITHOUT LOGIN
            CheckIfSessionActive checkIfSessionActive = new CheckIfSessionActive();
            if (checkIfSessionActive.IfInvalid(userCred.Username))
                mess = "Session was Expired. Logging in Again \n" ;
            DatabaseLoginServices databaseLoginServices = new DatabaseLoginServices();
            int i = databaseLoginServices.GetLogIdOfUSer(userCred.Username);//to check if the user is already logged in
            if (i == 0)
            {
                var token = jwtAuthenticationManager.GenerateTokenIfValid(userCred.Username, userCred.Password, 0);//Generate JWT token only when Login Creds Match
                if (token == null)
                    return Unauthorized(new { Status = "Error", Message = "Wrong credentials" });
                new GenerateRefreshToken(userCred.Username);//Generate Refresh Token
                return Ok(new { Status = mess+"Success",username = userCred.Username, JwtToken = token });
            }
            return Unauthorized(new { Status = "Error", Message = "Already Logged In...!!   Land User In Home Page" });
        }


        [HttpPost("logout")]//All Done
        public IActionResult Logout([FromBody] LogoutModel userCred)
        {
            DatabaseLogoutServices databaseLogoutServices = new DatabaseLogoutServices();
            databaseLogoutServices.Logout(userCred.Username, HttpContext.Request.Headers["Authorization"]);
            return Ok(new { Status = "Success", Message = "Successfully Logged Out"});
        }


        [AllowAnonymous]
        [HttpPost("register")]//All Done
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            DatabaseRegisterServices databaseRegisterServices = new DatabaseRegisterServices();
            if (!databaseRegisterServices.RegisterRecordsIfValid(registerModel))
                return StatusCode(StatusCodes.Status200OK,
                    new  { Status = "Success", Message = "User created successfully!" });
            return StatusCode(StatusCodes.Status400BadRequest,
                new  { Status = "Error", Message = "FAILED why? user already exist or not invited..!!" });
        }


        [AllowAnonymous]
        [HttpPost("refresh")]//All Done
        public IActionResult Refresh([FromBody] TokenValidationBody refreshToken)
        {
            CheckBlacklist checkBlacklist = new CheckBlacklist();
            if (checkBlacklist.IfPresent(refreshToken.Token)) 
                return StatusCode(StatusCodes.Status400BadRequest,
                 new { Status = "Error", Message = "Token Invalidated, request with new token" });
            RefreshJWTTokenIfValid refresh = new RefreshJWTTokenIfValid(jwtAuthenticationManager);
            return refresh.RefreshTokenIfValid( refreshToken);
        }
    }
}

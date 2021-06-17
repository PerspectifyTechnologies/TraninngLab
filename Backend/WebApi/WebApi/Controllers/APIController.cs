using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using WebApi.AuthenticationServices.CheckSession;
using WebApi.DatabaseServices;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public APIController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult GetAuth([FromBody]CurrentSession currentSession)//All not Done
        {
            //////these are the basic mandotary checks before accessing any authorised content
            //CheckIfSessionActive checkIfSessionActive = new CheckIfSessionActive();
            //if (checkIfSessionActive.IfInvalid(currentSession.Username))//check if the refresh token is expired, if false then continue, else land user in login page
            //    return StatusCode(StatusCodes.Status400BadRequest,
            //     new { Status = "Error", Message = "Session Expired. Login Again" });
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
            //check if the refresh token is expired, then continue, else land user in login page
            //CheckIfSessionActive checkIfSessionActive = new CheckIfSessionActive();
            //if (checkIfSessionActive.IfInvalid(userCred.Username))
            //    return StatusCode(StatusCodes.Status400BadRequest,
            //     new { Status = "Error", Message = "Session Expired. Login Again" });
            DatabaseLoginServices databaseLoginServices = new DatabaseLoginServices();
            int i = databaseLoginServices.GetLogIdOfUSer(userCred.Username);//to check if the user is already logged in
            if (i == 0)
            {
                var token = jwtAuthenticationManager.GenerateTokenIfValid(userCred.Username, userCred.Password);//Generate JWT token only when Login Creds Match
                if (token == null)
                    return Unauthorized(new { Status = "Error", Message = "Wrong credentials" });
                new GenerateRefreshToken(userCred.Username);//Generate Refresh Token
                return Ok(new { Status = "Success", JwtToken = token });
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
                new  { Status = "Error", Message = "User creation failed! User already exists." });
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

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthServices.Authentication;
using WebApi.AuthServices.Models;
using WebApi.RefreshToken;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    [Authorize]
    public class ApiController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public ApiController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "";
        }

        //to get authorized access
        [HttpGet]
        [Route("Home")]
        public IActionResult GetAuth()
        {
            if (new CheckBlacklist().IfPresent(HttpContext.Request.Headers["Authorization"].ToString().Substring(7)))
                return Unauthorized(new { Status = "Error"});
            return Ok(new { Status = "Success"});
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel credentials)
        {
            string message = "";
            if (new CheckIfSessionActive().IfInvalid(credentials.Username))
                message = "Session was Expired. Logging in Again !\n" ;
            if (new LoginServices().GetLogIdOfUSer(credentials.Username) == 0)
            {
                var token = jwtAuthenticationManager
                            .GenerateTokenIfValid(credentials.Username, credentials.Password, false);
                if (token == null)
                    return Unauthorized(new { Status = "Error",
                                              Message = "Wrong credentials" });
                new GenerateRefreshToken(credentials.Username);
                return Ok(new { Status = message+" Success",
                                Username = credentials.Username,
                                JwtToken = token });
            }
            return Unauthorized(new { Status = "Error", 
                                      Message = "Already Logged In" });
        }


        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutModel credentials)
        {
            new LogoutServices().Logout(credentials.Username, HttpContext.Request.Headers["Authorization"]);
            return Ok(new { Status = "Success",
                            Message = "Successfully Logged Out"});
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            if (!new RegisterServices().RegisterRecordsIfValid(registerModel))
                return Ok(new  { Status = "Success",
                                 Message = "User created successfully!" });
            return Unauthorized(new  { Status = "Error",
                                       Message = "FAILED why? user already exist or not invited..!!" });
        }


        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenValidationBody refreshToken)
        {
            if (new CheckBlacklist().IfPresent(refreshToken.Token)) 
                return Unauthorized(new { Status = "Error",
                                          JwtToken = "" });
            return new RefreshJWTTokenIfValid(jwtAuthenticationManager)
                            .RefreshTokenIfValid(refreshToken); 
        }
    }
}

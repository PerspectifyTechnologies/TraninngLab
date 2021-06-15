using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApi.DatabaseModel;

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
        public string GetAuth()
        {
            return "Authorized";
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel userCred)
        {
            var token = jwtAuthenticationManager.Login(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized(new { Status = "Error", Message = "Wrong credentials"});
            new GenerateRefreshToken(userCred.Username);
            return Ok(new {Status = "Success", JwtToken = token});
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            DatabaseRegisterServices databaseRegisterServices = new DatabaseRegisterServices();
            if (!databaseRegisterServices.RecordExists(registerModel))
                return StatusCode(StatusCodes.Status200OK, new  { Status = "Success", Message = "User created successfully!" });
            return StatusCode(StatusCodes.Status400BadRequest, new  { Status = "Error", Message = "User creation failed! User already exists." });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenValidationBody refreshToken)
        {
            Refresh refresh = new Refresh(jwtAuthenticationManager);
            return refresh.RefreshTokenIfValid( refreshToken);
        }
    }
}

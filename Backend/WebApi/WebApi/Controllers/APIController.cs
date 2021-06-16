using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
<<<<<<< Updated upstream
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApi.DatabaseModel;
using WebApi.RefreshTokenGeneration;
=======
using WebApi.DatabaseServices;
>>>>>>> Stashed changes

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
        public IActionResult GetAuth()
        {
            CheckBlacklist checkBlacklist = new CheckBlacklist();
            if (checkBlacklist.IfPresent(HttpContext.Request.Headers["Authorization"]))
                return StatusCode(StatusCodes.Status400BadRequest,
                 new { Status = "Error", Message = "Session Expired. Login Again" });
            return Ok(new { Status = "Success", OnlyAuthorizedMembers = "will see this message" });
        }


        [AllowAnonymous]
        [HttpPost("login")]//All Done
        public IActionResult Login([FromBody] LoginModel userCred)
        {
            DatabaseLoginServices databaseLoginServices = new DatabaseLoginServices();
            int i = databaseLoginServices.GetLogIdOfUSer(userCred.Username);//to check if the user is already logged in
            if (i == 0)
            {
                var token = jwtAuthenticationManager.GenerateTokenIfValid(userCred.Username, userCred.Password);//Generate JWT token only when Login Creds Match
                if (token == null)
                    return Unauthorized(new { Status = "Error", Message = "Wrong credentials" });
                new GenerateRefreshToken(userCred.Username);
                return Ok(new { Status = "Success", JwtToken = token });
            }
            return Unauthorized(new { Status = "Error", Message = "Already Logged In" });
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
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenValidationBody refreshToken)
        {
<<<<<<< Updated upstream
            Refresh refresh = new Refresh(jwtAuthenticationManager);
            return refresh.RefreshTokenIfValid(refreshToken);
=======
            CheckBlacklist checkBlacklist = new CheckBlacklist();
            if (checkBlacklist.IfPresent(HttpContext.Request.Headers["Authorization"])) 
                return StatusCode(StatusCodes.Status400BadRequest,
                 new { Status = "Error", Message = "Session Expired. Login Again" });
            RefreshJWTTokenIfValid refresh = new RefreshJWTTokenIfValid(jwtAuthenticationManager);
            return refresh.RefreshTokenIfValid( refreshToken);
>>>>>>> Stashed changes
        }
    }
}

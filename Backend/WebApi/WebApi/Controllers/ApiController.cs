using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.AuthServices;
using WebApi.AuthServices.Models;
using WebApi.RefreshToken;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
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
        [Authorize]
        [HttpGet]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            if (CheckBlacklist.Instance.IfPresent(HttpContext.Request.Headers["Authorization"].ToString().Substring(7)))
                return Unauthorized(new { Status = "Error"});
            return Ok(new { Status = "Success"});
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel credentials)
        {
            string message = "";
            if (CheckIfSessionActive.Instance.IfInvalid(credentials.Username))
                message = "Session was Expired. Logging in Again !\n" ;
            if (LoginServices.Instance.GetLogIdOfUSer(credentials.Username) == 0)
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


        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutModel credentials)
        {
            LogoutServices.Instance.Logout(credentials.Username, credentials.token);
            return Ok(new { Status = "Success",
                            Message = "Successfully Logged Out"});
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            if (!RegisterServices.Instance.RegisterRecordsIfValid(registerModel))
                return Ok(new  { Status = "Success",
                                 Message = "User created successfully!" });
            return Unauthorized(new  { Status = "Error",
                                       Message = "FAILED why? user already exist or not invited..!!" });
        }


        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenValidationBody refreshToken)
        {
            
            if (CheckBlacklist.Instance.IfPresent(refreshToken.Token)) 
                return Unauthorized(new { Status = "Error",
                                          JwtToken = "" });
            return new RefreshJWTTokenIfValid(jwtAuthenticationManager)
                            .RefreshTokenIfValid(refreshToken); 
        }
    }
}

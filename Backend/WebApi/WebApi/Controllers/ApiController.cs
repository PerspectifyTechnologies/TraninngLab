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

        [Authorize]
        [HttpGet]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            return Ok(new { Status = "Success"});
            //bydefault [Authorize] will give 401 status on unauthorized use of jwt token
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserPayload credentials)
        {
            string message = "";
            if (CheckIfSessionActive.Instance.IfInvalid(credentials.Username))
                message = "Session was Expired. Logging in Again !\n" ;
            if (LoginServices.Instance.GetLogIdOfUSer(credentials.Username) == 0)
            {
                var token = jwtAuthenticationManager
                            .GenerateTokenIfValid(credentials.Username, credentials.Payload, false);
                if (token == null)
                    return Unauthorized(new { Status = "Error",
                                              Message = "Wrong credentials" });
                new GenerateRefreshToken(credentials.Username);
                return Ok(new { Status = message+" Success",
                                Username = credentials.Username,
                                JwtToken = token });
            }
            else//temporary fix for front end routing issue
            {
                LoginServices.Instance.RemovePrevious(credentials.Username);
                var token = jwtAuthenticationManager
                            .GenerateTokenIfValid(credentials.Username, credentials.Payload, false);
                if (token == null)
                    return Unauthorized(new
                    {
                        Status = "Error",
                        Message = "Wrong credentials"
                    });
                new GenerateRefreshToken(credentials.Username);
                return Ok(new
                {
                    Status = message + "already loggedin Success",
                    Username = credentials.Username,
                    JwtToken = token
                });

            }
        }


        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] UserPayload credentials)
        {
            LogoutServices.Instance.Logout(credentials.Username, credentials.Payload);
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
        [HttpPost("refresh/{token}")]
        public IActionResult Refresh( string token)
        {
            return new RefreshJWTToken(jwtAuthenticationManager).RefreshTokenIfValid(token); 
        }
    }
}

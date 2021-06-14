using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("refresh")]
        //public async Task<ActionResult<LoginResponse>> Refresh([FromBody] RefreshRequest request)
        //{
        //    var loginResponse = AuthorizationService.Refresh(request.accessToken, refreshToken);

        //    LoginResponse response = new LoginResponse();
        //    response.AccessToken = loginResponse.AccessToken;
        //    response.AccessTokenExpiration = loginResponse.AccessTokenExpiration;
        //    response.RefreshToken = loginResponse.RefreshToken;

        //    return response;
        //}

        //public class RefreshRequest
        //{
        //    public string AccessToken { get; set; }
        //    public string RefreshToken { get; set; }
        //}

        //public class LoginResponse
        //{
        //    public string AccessToken { get; set; }
        //    public DateTimeOffset AccessTokenExpiration { get; set; }
        //    public string RefreshToken { get; set; }
        //}
    }
}

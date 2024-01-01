using Azure;
using CRUD.Dto;
using CRUD.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationBiz _biz;
        private IConfiguration _config;
        private ILogger<RegistrationController> _logger;
        public RegistrationController(IRegistrationBiz biz, IConfiguration config, ILogger<RegistrationController> logger)
        {
            _biz = biz;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> AddUser(Registration registration)
        {
            try
            {
                var user = await _biz.AddUserAsync(registration);
                _logger.LogInformation("Users", user);
                return CreatedAtAction(nameof(AddUser), user);
            }
            catch (Exception ex)
            {
                return Ok(new { exception = ex, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> ValidateUser(Registration registration)
        {
            IActionResult response = Unauthorized();
            (bool isValidUser, Registration user) = _biz.ValidateUser(registration.Email, registration.Password);
            if (isValidUser)
            {
                var token = GenerateToken(registration);
                response = Ok(new { token = token, userName = user.Name, userId =  user.Id, userEmail =  user.Email });
            }
            _logger.LogInformation("Validate User", response);
            return response;
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<List<Registration>> GetUsers()
        {
            var users = _biz.GetUserList();
            _logger.LogInformation("Validate User", users);
            return users;
        }

        private string GenerateToken(Registration registration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

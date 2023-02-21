using BusinessObject;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly User _adminAccount;
        private readonly IConfiguration _config;
        private readonly JwtOption _jwtOption;
        private readonly IUnitOfWork _unitOfWork;
        private class JwtOption
        {
            public string? Key { get; set; }
            public string? Issuer { get; set; }
            public string? Audience { get; set; }
        }
        public LoginController(IConfiguration config, IUnitOfWork unitOfWork)
        {

            _config = config;
            _unitOfWork = unitOfWork;
            _adminAccount = new User()
            {
                email_address = _config.GetSection("eStoreAccount")["Email"],
                password = _config.GetSection("eStoreAccount")["Password"]
            };
            _jwtOption = new JwtOption()
            {
                Key = _config.GetSection("Jwt:Key").Value,
                Issuer = _config.GetSection("Jwt:Issuer").Value,
                Audience = _config.GetSection("Jwt:Audience").Value,
            };
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? token)
        {
            try
            {
                if (token == null)
                {
                    return BadRequest();
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                string email = jwtToken.Payload.Claims.First(claim => claim.Type == "email").Value;
                if (email == _adminAccount.email_address)
                {
                    return Ok(_adminAccount);
                }
                else
                {
                    string role = jwtToken.Payload.Claims.First(claim => claim.Type == "role").Value;
                    var find = await _unitOfWork.UserRepository.Get(expression: m => m.email_address == email);
                    var login = find.FirstOrDefault();
                    return Ok(login);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string email, [FromQuery] string password)
        {
            //try login as Administrator
            if (email == _adminAccount.email_address && password == _adminAccount.password)
            {
                var claims = new Claim[]
                {
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim("id", "0")
                };
                return Ok(GenerateToken(claims));
            }
            else
            {
                var login = await _unitOfWork.UserRepository.LoginAsync(email, password);
                if (login != null)
                {
                    var claims = new Claim[]
                    {
                            new Claim("id", login.user_id.ToString()),
                            new Claim(ClaimTypes.Email, login.email_address),
                            new Claim(ClaimTypes.Role, login.role_id.ToString()),
                    };
                    return Ok(GenerateToken(claims));
                }
                else
                {
                    return Unauthorized();
                }
            }

        }
        private string GenerateToken(Claim[] claims)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Issuer = _jwtOption.Issuer,
                Audience = _jwtOption.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }
    }
}


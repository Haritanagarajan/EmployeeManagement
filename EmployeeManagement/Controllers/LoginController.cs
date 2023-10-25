#nullable disable
using EmployeeManagement.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly DbEmployeeManagementContext _context;
        public LoginController(DbEmployeeManagementContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("TokenGenerate")]
        public IActionResult Login(LoginDetailsModel loginDetails)
        {
            var employee = _context.EmployeeMasters.FirstOrDefault(x => x.Username == loginDetails.Username && x.Password == loginDetails.Password);
            if (employee == null)
            {
                return BadRequest(new Persistence.Models.Responce
                {
                    Status = "Failed",
                    Title = "Employee Details is Null"
                });
            }
            else
            {
                IActionResult token = GetToken(employee);
                if (token is OkObjectResult objectResult)
                {
                    string jwtToken = objectResult.Value?.ToString();
                    var response = new Persistence.Models.LoginTokenDetails
                    {
                        Username = loginDetails.Username,
                        Password = loginDetails.Password,
                        Token = jwtToken,
                        Id = employee.Id
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new Persistence.Models.Responce
                    {
                        Status = "Failed",
                        Title = "Token Failed"
                    });
                }
            }
        }

        [HttpPost]
        public IActionResult GetToken(EmployeeMaster employee)
        {
            var username = employee.Username;
            var userRole = "no role";
            if (username == "Administrator")
            {
                userRole = "Admin";
            }
            else if (username != "Administrator")
            {
                userRole = "Employee";
            }
            else
            {
                return BadRequest("User does not have a role.");
            }

            var key = "erdf7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs05hri";
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, employee.Username),
                 new Claim(JwtRegisteredClaimNames.Sub,employee.Id.ToString()),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: "JWTAuthenticationServer",
                audience: "JWTServicePostmanClient",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);
        }
    }
}

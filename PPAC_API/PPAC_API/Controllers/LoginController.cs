using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PPAC_API.DAL.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        private User AuthenticateUsers(User user)
        {
            User correntUser = null;
            if (user.UserName == "admin" && user.Password == "12345")
            {
                correntUser = new User { Name = "Santhosh" };
            }
            return correntUser;

        }

        private string GenerateJwtToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult res = Unauthorized();
            var validateUser = AuthenticateUsers(user);
            if (validateUser != null)
            {
                var token = GenerateJwtToken(validateUser);

                res = Ok(new { token = token });

            }

            return res;
        }

    }
}


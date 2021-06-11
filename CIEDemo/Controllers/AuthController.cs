using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIEDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CIEDemo.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        // POST: api/auth/login
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            // using hardcoded username and password for the sake of simplicity, real world examples would of course never have this
            if (user.UserName == "johndoe" && user.Password == "cie2021")
            {
                // configuration of JWT options, this is also where if you wanted to do role-based authentication, you could configure that via the claims property
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@12345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:61654",
                    audience: "http://localhost:61654",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signingCredentials
                );

                // creation of JWT token, using above options
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.DTOs.User;
using WebApi.Entities;
using WebApi.Repositories.User;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserRepository _context;
        IConfiguration _configuration;


        public AuthenticationController(IConfiguration configuration, IUserRepository context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationDto authenticationDto)
        {
            var user = _context.GetByUsername(authenticationDto.Username);

            if (!_context.IsAuthenticated(user))
            {
                return Unauthorized();
            }


            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
            );
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256
            );
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("Id", user.Id.ToString()));
            claimsForToken.Add(new Claim("Username", user.Username));


            var jwtSecurityToke = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.Now,
                DateTime.Now.AddSeconds(5),
                signingCredentials
            );

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToke);
            return Ok(tokenToReturn);
        }
    }
}

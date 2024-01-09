using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.User
{
    public class AuthenticationDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

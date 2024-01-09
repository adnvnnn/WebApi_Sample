using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    [Index(nameof(Username), IsUnique = true)]

    public class UserTbl :SeedEntity
    {
        public UserTbl(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        [MaxLength(10)]

        public string Username { get; set; }

        [Required]
        [MaxLength(10)] 
        public string Password { get; set; }
    }
}

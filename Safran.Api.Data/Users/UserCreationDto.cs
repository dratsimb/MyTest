using System.ComponentModel.DataAnnotations;

namespace Safran.Api.Data.Users
{
    public class UserCreationDto:UserDto
    {
        [MinLength(12)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Safran.Api.Data.Users
{
    public class PasswordChange
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(12)]
        public string NewPassword { get; set; }
    }
}

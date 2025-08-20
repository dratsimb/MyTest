using System;
using System.ComponentModel.DataAnnotations;

namespace Safran.Api.Data.Users
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        [MinLength(1)]
        public string Name { get; set; }

        [MinLength(1)]
        public string LastName { get; set; }

        [MinLength(5)]
        public string Email { get; set; }

        [MinLength(5)]
        public string Login {  get; set; }
    }
}
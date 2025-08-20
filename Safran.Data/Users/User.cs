using System;

namespace Safran.Data.Users
{
    public class User
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }
    }
}

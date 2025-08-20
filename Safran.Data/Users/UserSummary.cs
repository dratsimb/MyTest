using System;

namespace Safran.Data.Users
{
    public class UserSummary
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public int SubmitedFlowersCount { get; set; }
    }
}

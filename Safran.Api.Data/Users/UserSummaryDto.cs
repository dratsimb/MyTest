using System;

namespace Safran.Api.Data.Users
{
    public class UserSummaryDto
    {
        public Guid Id { get; set; }

        public string Login { get;set; }

        public int SubmitedFlowersCount {  get; set; }
    }
}

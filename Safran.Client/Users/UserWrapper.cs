using Safran.Api.Data.Users;

namespace Safran.Client.Users
{
    public class UserWrapper(string uri) : BaseWrapper(uri)
    {

        public Task<UserDto> GetAsync(Guid Id)
        {
            return Task.FromResult(new UserDto() { Id = Id });
        }
    }
}

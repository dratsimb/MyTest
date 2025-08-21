using Safran.Api.Data.Users;

namespace Safran.Client.Users
{
    public class UserListWrapper:BaseWrapper
    {
        public UserListWrapper(string rootUri) :base (rootUri)
        {
            _userWrapper = new Lazy<UserWrapper>(() => new UserWrapper(rootUri));
        }

        Lazy<UserWrapper> _userWrapper;
        public UserWrapper User => _userWrapper.Value;

        public UserDto this[Guid id]
        {
            get
            {
                // évite les deadlocks de GetAwaiter().GetResult()
                return Task.Run(async () =>
                {
                    return await User.GetAsync(id);
                }).GetAwaiter().GetResult(); 
            }
        }
    }
}

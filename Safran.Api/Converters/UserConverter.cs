using Safran.Api.Data.Users;
using Safran.Data.Users;

namespace Safran.Api.Converters
{
    public static class UserConverter
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                Email = user.Email,
                Id = user.Id,
                LastName = user.LastName,
                Login = user.Login,
                Name = user.Name
            };
        }


        public static User ToDbModel(this UserDto user)
        {
            return new()
            {
                Email = user.Email,
                Id = user.Id,
                LastName = user.LastName,
                Login = user.Login,
                Name = user.Name
            };
        }

        public static UserSummaryDto ToDto(this UserSummary src)
        {
            return new()
            {
                Login = src.Login,
                Id = src.Id,
                SubmitedFlowersCount = src.SubmitedFlowersCount,
            };
        }

        public static IEnumerable<UserSummaryDto>? ToDto(this IList<UserSummary> src)
        {
            return src?.Select(x => x.ToDto());
        }
    }
}

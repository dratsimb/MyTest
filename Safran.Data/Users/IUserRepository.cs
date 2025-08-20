using Safran.Data.Users;
using System;

namespace Safran.Data.Users
{
    public interface IUserRepository
    {
        Guid Add(string username, string password);

        (UserSummary[], int) Get(int page, int pageSize);

        User Get(Guid id);
        
        int Update(User user);

        int Delete(Guid id);

        bool Exists(string login);

        void SetPassword(Guid id, byte[] encodedPassword);

        bool IsMatching(Guid id, byte[] encodedPassword);

    }
}
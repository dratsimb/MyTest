using Safran.Data.Users;
using System.Data;

namespace Safran.Data.Sql
{
    public class UserRepository(IConnectionProvider connectionProvider) : BaseRepository(connectionProvider), IUserRepository
    {
        public Guid Add(string username, string password) { throw new NotImplementedException(); }

        public User Get(Guid id) 
        {
            return new()
            {
                Email = "toto@titi.tutu",
                Id = Guid.NewGuid(),
                LastName = "tilt",
                Login = "Risoto",
                Name = "curry"
            };
        }

        public (UserSummary[], int) Get(int page, int pageSize)
        {
            return (
                [
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "a",
                        SubmitedFlowersCount = 2
                    },
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "b",
                        SubmitedFlowersCount = 2
                    },
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "c",
                        SubmitedFlowersCount = 2
                    },
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "d",
                        SubmitedFlowersCount = 2
                    },
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "e",
                        SubmitedFlowersCount = 2
                    },
                    new UserSummary
                    {
                        Id = Guid.NewGuid(),
                        Login = "f",
                        SubmitedFlowersCount = 2
                    },
                ], 6);
        }

        public int Delete(Guid id) 
        { 
            return 1; 
        }

        public bool Exists(string login)
        {
            return false;
        }

        public int Update(User user)
        {
            return 1;
        }

        void IUserRepository.SetPassword(Guid id, byte[] encodedPassword)
        {
            
        }

        bool IUserRepository.IsMatching(Guid id, byte[] encodedPassword)
        {
            return true;
        }
    }
}
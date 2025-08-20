using System.Data;

namespace Safran.Data.Sql
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}

using System.Data;

namespace Safran.Data.Sql
{
    public class BaseRepository(IConnectionProvider connectionProvider)
    {
        public IDbConnection Connection { get;  } = connectionProvider.GetConnection();
    }
}

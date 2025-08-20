using System.Data.SqlClient;
using Safran.Data.Sql;
using System.Data;

namespace Safran.Api.Adapters
{
    [Obsolete]
    public class ObsoleteConnectionProvider
    : IConnectionProvider
    {
        IDbConnection IConnectionProvider.GetConnection()
        {
            var sqlConnection = "";
            return new SqlConnection(sqlConnection);
        }
    }
}

using Safran.Data.Sql;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Safran.Api.Adapters
{
    public class ConnectionProvider:IConnectionProvider
    {
        IDbConnection IConnectionProvider.GetConnection()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var sqlConnection = configuration.GetConnectionString("myConnection");

            return new SqlConnection(sqlConnection);
        }
    }
}

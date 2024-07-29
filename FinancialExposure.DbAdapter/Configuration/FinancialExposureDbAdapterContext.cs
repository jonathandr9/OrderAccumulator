using Microsoft.Data.Sqlite;
using System.Data;

namespace FinancialExposure.DbAdapter.Configuration
{
    public class FinancialExposureDbAdapterContext
    {
        private readonly string connectionString;

        public FinancialExposureDbAdapterContext(
            string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection dbConnection;

        public IDbConnection Connection
        {
            get
            {
                if (dbConnection == null)
                    dbConnection = new SqliteConnection(connectionString);

                return dbConnection;
            }
        }
    }
}

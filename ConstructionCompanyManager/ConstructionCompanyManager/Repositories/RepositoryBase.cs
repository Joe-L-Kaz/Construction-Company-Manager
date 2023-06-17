using System.Configuration;
using System.Data.SqlClient;

namespace ConstructionCompanyManager.Repositories
{
    public class RepositoryBase
    {
        private readonly string connectionString;

        public RepositoryBase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConstructionCompanyDb"].ConnectionString;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
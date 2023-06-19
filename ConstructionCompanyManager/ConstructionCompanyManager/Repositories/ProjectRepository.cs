using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConstructionCompanyManager.Repositories
{
    public class ProjectRepository : RepositoryBase
    {
        public bool IsProjectTableEmpty()
        {
            bool projectTableIsEmpty;
            
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "select * from Project";
                    
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    List<int> projIds = new List<int>();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projId = reader.GetInt32(0);
                            projIds.Add(projId);
                        }

                        if (projIds.Count == 0)
                        {
                            return true;
                        }

                        return false;

                    }
                }
            }
        }
    }
}
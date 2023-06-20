using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using ConstructionCompanyManager.Model;

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

                using (SqlCommand cmd = new SqlCommand(query, connection))
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

        public DataTable GetAllProjects()
        {
            string query = "select * from Project";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, GetConnection());

            using (sqlDataAdapter)
            {
                DataTable projectDataTable = new DataTable();
                sqlDataAdapter.Fill(projectDataTable);
                return projectDataTable;
            }
        }

        public ProjectModel GetFirstProjectModel()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "select * from Project";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int projId = default;
                        string projName = default;
                        bool projIsTaxRefund = default;
                        
                        while (reader.Read())
                        { 
                            projId = reader.GetInt32(0);
                            projName = reader.GetString(1);
                            projIsTaxRefund = reader.GetBoolean(2);
                        }

                        ProjectModel project = new ProjectModel(projId, projName, projIsTaxRefund);
                        
                        return project;

                    }
                }
            }
        }

        
    }
}
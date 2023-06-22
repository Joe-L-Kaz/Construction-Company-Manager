using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using ConstructionCompanyManager.Model;

namespace ConstructionCompanyManager.Repositories
{
    public class ProjectRepository : RepositoryBase
    {
        public bool IsProjectTableEmpty()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Project";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    int rowCount = (int)cmd.ExecuteScalar();
                    return rowCount == 0;
                }
            }
        }

        public ObservableCollection<ProjectModel> GetAllProjects()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "select * from Project";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ObservableCollection<ProjectModel> allProjects = new ObservableCollection<ProjectModel>();

                        while (reader.Read())
                        {
                            int projId = reader.GetInt32(0);
                            string projName = reader.GetString(1);
                            bool projIsTaxRefund = reader.GetBoolean(2);

                            ProjectModel project = new ProjectModel(projId, projName, projIsTaxRefund,
                                GetProjectSales(projId), GetProjectPurchases(projId));

                            allProjects.Add(project);
                        }

                        reader.Close();

                        return allProjects;
                    }
                }
            }
        }

        private ObservableCollection<float> GetProjectSales(int projectId)
        {
            string query =
                "SELECT s.SaleAmount FROM ProjectSales s JOIN Project p ON s.ProjectId = p.Id WHERE p.Id = @projectId;";
            return GetProjectData(projectId, query);
        }

        private ObservableCollection<float> GetProjectPurchases(int projectId)
        {
            string query =
                "SELECT s.PurchaseAmount FROM ProjectPurchases s JOIN Project p ON s.ProjectId = p.Id WHERE p.Id = @projectId;";
            return GetProjectData(projectId, query);
        }


        private ObservableCollection<float> GetProjectData(int projectId, string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ObservableCollection<float> projectData = new ObservableCollection<float>();

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                float data = (float)reader.GetDouble(0);
                                projectData.Add(data);
                            }
                        }

                        return projectData;
                    }
                }
            }
        }
    }
}
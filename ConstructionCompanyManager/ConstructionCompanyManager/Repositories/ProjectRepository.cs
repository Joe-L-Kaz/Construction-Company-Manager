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

                        return allProjects;
                    }
                }
            }
        }

        private ObservableCollection<float> GetProjectSales(int projectId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    $"SELECT s.SalesAmount FROM ProjectSales s JOIN Project p ON s.ProjectId = p.Id WHERE p.Id = @projectId;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ObservableCollection<float> allProjectSales = new ObservableCollection<float>();

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                float sale = (float)reader.GetDouble(0);
                                allProjectSales.Add(sale);
                            }
                        }

                        return allProjectSales;
                    }
                }
            }
        }

        private ObservableCollection<float> GetProjectPurchases(int projectId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT s.PurchaseAmount FROM ProjectPurchases s JOIN Project p ON s.ProjectId = p.Id WHERE p.Id = @projectId;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ObservableCollection<float> allProjectPurchases = new ObservableCollection<float>();

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                float purchase = (float)reader.GetDouble(0);
                                allProjectPurchases.Add(purchase);
                            }
                        }

                        return allProjectPurchases;
                    }
                }
            }
        }
    }
}
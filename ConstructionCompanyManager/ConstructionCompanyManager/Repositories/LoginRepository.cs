using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using ConstructionCompanyManager.Model;

namespace ConstructionCompanyManager.Repositories
{
    public class LoginRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;

            using (SqlConnection connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Login] where username = @Username and [password] = @Password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }

            return validUser;
        }
    }
}
using System.Collections.Generic;
using System.Net;
using ConstructionCompanyManager.Model;

namespace ConstructionCompanyManager.Repositories
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
    }
}
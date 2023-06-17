namespace ConstructionCompanyManager.Model
{
    public class LoginModel
    {
        // Constructor
        public LoginModel(int id, string username, string password)
        {
            _id = id;
            _username = username;
            _password = password;
        }

        //fields
        private int _id;
        private string _username;
        private string _password;
        
        //properties
        public int Id
        {
            get { return _id;}
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using ConstructionCompanyManager.Commands;
using ConstructionCompanyManager.Model;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        
        private IUserRepository _userRepository;
        
        // Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        
        public ICommand LoginCommand { get; private set; }
        
        public LoginViewModel()
        {
            _userRepository = new LoginRepository();
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }
        
        private void ExecuteLoginCommand(object obj)
        {
            bool isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool isUsernameOrPasswordValid;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                isUsernameOrPasswordValid = false;
            
            else
                isUsernameOrPasswordValid = true;

            return isUsernameOrPasswordValid;
        }

    }
}
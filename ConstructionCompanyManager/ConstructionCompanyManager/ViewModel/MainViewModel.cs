using System.Windows;
using System.Windows.Input;
using ConstructionCompanyManager.Commands;
using ConstructionCompanyManager.Repositories;
using ConstructionCompanyManager.View;

namespace ConstructionCompanyManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _errorMessage;
        private bool _isViewVisible = true;

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

        public MainViewModel()
        {
            ShowProjectSummaryCommand =
                new RelayCommand(ExecuteShowProjectSummaryCommand, CanExecuteShowProjectSummaryCommand);
        }

        public ICommand AddNewProjectCommand { get; private set; }
        public ICommand LoadProjectFromFileCommand { get; private set; }
        public ICommand EditExistingProjectCommand { get; private set; }
        public ICommand ShowProjectSummaryCommand { get; private set; }

        private void ExecuteShowProjectSummaryCommand(object obj)
        {
            MessageBox.Show("Test");
        }

        private bool CanExecuteShowProjectSummaryCommand(object obj)
        {
            ProjectRepository projRepo = new ProjectRepository();

            if (projRepo.IsProjectTableEmpty())
            {
                return false;
            }

            return true;
        }
    }
}
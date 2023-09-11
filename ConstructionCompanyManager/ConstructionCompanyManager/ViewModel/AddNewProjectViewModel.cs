using System.Collections.ObjectModel;
using System.Windows.Input;
using ConstructionCompanyManager.Commands;
using ConstructionCompanyManager.Model;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.ViewModel
{
    public class AddNewProjectViewModel : ViewModelBase
    {
        private bool _isViewVisible = true;
        private ObservableCollection<ProjectModel> _projectTable;
        private ProjectRepository _projectRepository;

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ObservableCollection<ProjectModel> ProjectTable
        {
            get => _projectTable;
            private set
            {
                _projectTable = value;
                OnPropertyChanged(nameof(ProjectTable));
            }
        }

        public AddNewProjectViewModel()
        {
            _projectRepository = new ProjectRepository();
            AddNewBuildCommand = new RelayCommand(ExecuteAddNewBuild);
            AddRenovationCommand = new RelayCommand(ExecuteAddRenovation);
            UpdateTable();
        }

        public ICommand AddNewBuildCommand { get; set; }
        public ICommand AddRenovationCommand { get; set; }

        private void ExecuteAddNewBuild(object obj)
        {
            _projectRepository.AddNewProject(new ProjectModel("New Build", true));
            UpdateTable();
        }

        private void ExecuteAddRenovation(object obj)
        {
            _projectRepository.AddNewProject(new ProjectModel("Renovation", false));
            UpdateTable();
        }

        private void UpdateTable()
        {
            ProjectTable = _projectRepository.GetAllProjects();
        }
        
    }
}
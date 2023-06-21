using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using ConstructionCompanyManager.Model;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.ViewModel
{
    public class ProjectSummaryViewModel : ViewModelBase
    {
        private ObservableCollection<ProjectModel> _projectTable;
        private bool _isViewVisible = true;
        private ProjectModel _projectModel;
        
        public ObservableCollection<ProjectModel> ProjectTable
        {
            get => _projectTable;
            private set
            {
                _projectTable = value;
                OnPropertyChanged(nameof(ProjectTable));
            }
        }
        
        public ProjectModel ProjectModel
        {
            get => _projectModel;
            private set
            {
                _projectModel = value;
                OnPropertyChanged(nameof(ProjectModel));
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

        public ProjectSummaryViewModel()
        {
            ProjectRepository projectRepository = new ProjectRepository();
            ProjectTable = projectRepository.GetAllProjects();
        }

    }
}
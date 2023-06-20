using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using ConstructionCompanyManager.Model;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.ViewModel
{
    public class ProjectSummaryViewModel : ViewModelBase
    {
        private ListBox _projectTable;
        private bool _isViewVisible = true;
        private ProjectModel _projectModel;
        
        public ProjectModel ProjectModel
        {
            get => _projectModel;
            private set
            {
                _projectModel = value;
                OnPropertyChanged(nameof(ProjectModel));
            }
        }
        public ListBox ProjectTable
        {
            get => _projectTable;
            private set
            {
                _projectTable = value;
                OnPropertyChanged(nameof(ProjectTable));
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
            ProjectModel = projectRepository.GetFirstProjectModel();
        }

    }
}
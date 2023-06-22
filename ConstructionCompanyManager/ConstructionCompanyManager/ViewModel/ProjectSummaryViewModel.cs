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
        private ProjectModel _selectedProject;
        private ObservableCollection<float> _selectedProjectSales;
        private ObservableCollection<float> _selectedProjectPurchases;

        public ObservableCollection<ProjectModel> ProjectTable
        {
            get => _projectTable;
            private set
            {
                _projectTable = value;
                OnPropertyChanged(nameof(ProjectTable));
            }
        }

        public ProjectModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
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

        public ObservableCollection<float> SelectedProjectSales
        {
            get => _selectedProjectSales;
            set
            {
                _selectedProjectSales = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public ObservableCollection<float> SelectedProjectPurchases
        {
            get => _selectedProjectPurchases;
            set
            {
                _selectedProjectPurchases = value;
                OnPropertyChanged(nameof(SelectedProjectPurchases));
            }
        }

        public ProjectSummaryViewModel()
        {
            ProjectRepository projectRepository = new ProjectRepository();
            ProjectTable = projectRepository.GetAllProjects();
        }
    }
}
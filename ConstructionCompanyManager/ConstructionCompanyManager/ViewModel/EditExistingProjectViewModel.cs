using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ConstructionCompanyManager.Commands;
using ConstructionCompanyManager.Model;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.ViewModel
{
    public class EditExistingProjectViewModel : ViewModelBase
    {
        private ObservableCollection<ProjectModel> _projectTable;
        private bool _isViewVisible = true;
        private ProjectModel _selectedProject;

        private string _saleAmountString;
        private string _purchaseAmountString;

        private readonly ProjectRepository _projectRepository;

        public ObservableCollection<ProjectModel> ProjectTable
        {
            get => _projectTable;
            set
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

        public ProjectModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public string SaleAmountString
        {
            get => _saleAmountString;
            set
            {
                _saleAmountString = value;
                OnPropertyChanged(nameof(SaleAmountString));
            }
        }

        public string PurchaseAmountString
        {
            get => _purchaseAmountString;
            set
            {
                _purchaseAmountString = value;
                OnPropertyChanged(nameof(PurchaseAmountString));
            }
        }

        public EditExistingProjectViewModel()
        {
            _projectRepository = new ProjectRepository();
            
            ProjectTable = _projectRepository.GetAllProjects();

            AddSaleToSelectedProjectCommand =
                new RelayCommand(ExecuteAddSaleToSelectedProject, CanExecuteAddSaleToSelectedProject);

            AddPurchaseToSelectedProjectCommand = new RelayCommand(ExecuteAddPurchaseToSelectedProject,
                CanExecuteAddPurchaseToSelectedProject);


            DeleteSelectedProjectCommand = new RelayCommand(ExecuteDeleteSelectedProject, CanExecuteDeleteSelectedProject);
        }

        public ICommand AddSaleToSelectedProjectCommand { get; private set; }
        public ICommand AddPurchaseToSelectedProjectCommand { get; private set; }
        public ICommand DeleteSelectedProjectCommand { get; private set; }

        private void ExecuteAddSaleToSelectedProject(object obj)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            projectRepository.AddSaleToProject(SelectedProject.Id, float.Parse(SaleAmountString));
            SaleAmountString = string.Empty;
        }

        private bool CanExecuteAddSaleToSelectedProject(object obj)
        {
            if (string.IsNullOrEmpty(SaleAmountString) || SelectedProject == null)
            {
                return false;
            }

            if (!float.TryParse(SaleAmountString, out float val))
            {
                return false;
            }

            return true;
        }

        private void ExecuteAddPurchaseToSelectedProject(object obj)
        {
            _projectRepository.AddPurchaseToProject(SelectedProject.Id, float.Parse(PurchaseAmountString));
            PurchaseAmountString = string.Empty;
        }

        private bool CanExecuteAddPurchaseToSelectedProject(object obj)
        {
            if (string.IsNullOrEmpty(PurchaseAmountString) || SelectedProject == null)
            {
                return false;
            }
            
            if (!float.TryParse(PurchaseAmountString, out float val))
            {
                return false;
            }

            return true;
        }

        private void ExecuteDeleteSelectedProject(object obj)
        {
            _projectRepository.DeleteProject(SelectedProject.Id);
            UpdateProjectTableOnDelete();
        }

        private bool CanExecuteDeleteSelectedProject(object obj)
        {
            if (SelectedProject == null)
            {
                return false;
            }

            return true;
        }
        private void UpdateProjectTableOnDelete()
        {
           ProjectTable = _projectRepository.GetAllProjects();
        }
    }
}
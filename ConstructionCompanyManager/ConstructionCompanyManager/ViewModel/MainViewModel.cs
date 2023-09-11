using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConstructionCompanyManager.Commands;
using ConstructionCompanyManager.Repositories;
using ConstructionCompanyManager.View;

namespace ConstructionCompanyManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isViewVisible = true;

        private readonly ProjectRepository _projectRepository;
        
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public MainViewModel()
        {
            _projectRepository = new ProjectRepository();
            
            AddNewProjectCommand = new RelayCommand(ExecuteAddNewProjectCommand);
            
            EditExistingProjectCommand =
                new RelayCommand(ExecuteEditExistingProjectCommand, CanExecuteEditExistingProjectCommand);
            
            ShowProjectSummaryCommand =
                new RelayCommand(ExecuteShowProjectSummaryCommand, CanExecuteShowProjectSummaryCommand);
        }

        public ICommand AddNewProjectCommand { get; private set; }
        public ICommand LoadProjectFromFileCommand { get; private set; }
        public ICommand EditExistingProjectCommand { get; private set; }
        public ICommand ShowProjectSummaryCommand { get; private set; }

        private void ExecuteEditExistingProjectCommand(object obj)
        {
            EditExistingProjectView editExistingProjectView = new EditExistingProjectView();
            editExistingProjectView.Show();
        }

        private bool CanExecuteEditExistingProjectCommand(object obj)
        {
            if (_projectRepository.IsProjectTableEmpty())
            {
                return false;
            }

            return true;
        }

        private void ExecuteShowProjectSummaryCommand(object obj)
        {
            //ShowProjectSummaryFrame.Content = new ProjectSummaryView();
            ProjectSummaryView projectSummaryView = new ProjectSummaryView();
            projectSummaryView.Show();

        }

        private bool CanExecuteShowProjectSummaryCommand(object obj)
        {
           if (_projectRepository.IsProjectTableEmpty())
           {
                return false;
           }
           
           return true;
        }

        private void ExecuteAddNewProjectCommand(object obj)
        {
            AddNewProjectView addNewProjectView = new AddNewProjectView();
            addNewProjectView.Show();
        }
    }
}
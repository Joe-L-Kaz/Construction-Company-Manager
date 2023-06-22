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
        private string _errorMessage;
        private bool _isViewVisible = true;
        private Frame _showProjectSummaryFrame = new Frame();

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

        public Frame ShowProjectSummaryFrame
        {
            get => _showProjectSummaryFrame;
            set
            {
                _showProjectSummaryFrame = value;
                OnPropertyChanged(nameof(ShowProjectSummaryFrame));
            }
        }
        

        public MainViewModel()
        {
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
            ProjectRepository projRepo = new ProjectRepository();

            if (projRepo.IsProjectTableEmpty())
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
            ProjectRepository projRepo = new ProjectRepository();

            if (projRepo.IsProjectTableEmpty())
            {
                return false;
            }

            return true;
        }
    }
}
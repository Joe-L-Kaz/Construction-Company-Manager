using System.Windows.Controls;
using ConstructionCompanyManager.Repositories;

namespace ConstructionCompanyManager.View
{
    public partial class ProjectSummaryView : Page
    {
        public ProjectSummaryView()
        {
            InitializeComponent();
            ShowProjects();
        }

        private void ShowProjects()
        {
            ProjectRepository projectRepository = new ProjectRepository();
            
            ProjectsDataGrid = projectRepository.GetAllProjects();
        }
    }
}
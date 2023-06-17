using System.Windows;
using ConstructionCompanyManager.View;

namespace ConstructionCompanyManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    TestView testView = new TestView();
                    testView.Show();
                    loginView.Close();
                }
            };
        }
    }
}
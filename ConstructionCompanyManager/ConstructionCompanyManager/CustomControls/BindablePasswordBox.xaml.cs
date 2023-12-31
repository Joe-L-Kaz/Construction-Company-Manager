using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace ConstructionCompanyManager.CustomControls
{
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set {SetValue(PasswordProperty, value);}
        }
        public BindablePasswordBox()
        {
            InitializeComponent();
            UserPasswordBox.PasswordChanged += OnPasswordChanged;
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = UserPasswordBox.SecurePassword;
        }
    }
}
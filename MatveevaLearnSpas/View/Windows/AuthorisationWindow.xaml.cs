using MatveevaLearnSpas.AppData;
using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatveevaLearnSpas.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private static MatveevaLearnSpasEntities _context = App.GetContext();
        public AuthorisationWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationHelper.Authorise(LoginTb.Text, PasswordTb.Password);
            if (AuthorisationHelper.selectedUser.IdRole == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                Close();
            }
        }

        private void PasswordRecoveryBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxHelper.Information("Обратитесь к системному администратору.");
        }
    }
}

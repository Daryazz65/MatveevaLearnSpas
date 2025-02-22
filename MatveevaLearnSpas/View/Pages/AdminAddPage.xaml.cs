using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatveevaLearnSpas.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminAddPage.xaml
    /// </summary>
    public partial class AdminAddPage : Page
    {
        private static MatveevaLearnSpasEntities _context = App.GetContext();
        public AdminAddPage()
        {
            InitializeComponent();
            UserDG.ItemsSource = _context.Users.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

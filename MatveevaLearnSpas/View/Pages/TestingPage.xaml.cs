using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatveevaLearnSpas.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestingPage.xaml
    /// </summary>
    public partial class TestingPage : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private static MatveevaLearnSpasEntities _context = App.GetContext();
        public TestingPage()
        {
            InitializeComponent();
            LoadTestingStatus();
        }
        private void LoadTestingStatus()
        {
            int userId = App.CurrentUser?.Id ?? 0;
            bool module1Completed = false;
            string query = "SELECT COUNT(*) FROM Testing WHERE IdUser = @userId AND IdSection = 1 AND Status = 1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    module1Completed = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            ModulTwoBtn.IsEnabled = module1Completed;
        }
        private void ModulTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(2));
        }
        private void ModulOneBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(1));
        }

        private void ModulThreeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul4Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul5Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul6Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul7Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul8Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul9Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul10Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul11Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul12Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul13Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul14Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul15Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul16Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul17Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul18Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modul19Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
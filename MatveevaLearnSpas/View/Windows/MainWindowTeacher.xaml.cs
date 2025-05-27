using MatveevaLearnSpas.AppData;
using MatveevaLearnSpas.View.Pages;
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
    /// Логика взаимодействия для MainWindowTeacher.xaml
    /// </summary>
    public partial class MainWindowTeacher : Window
    {
        public MainWindowTeacher()
        {
            InitializeComponent();
            JournalPage journalPage = new JournalPage();
            MainFrameTeacher.Navigate(journalPage);
            FrameHelper.selectedFrame = MainFrameTeacher;
        }
        private void GoOutBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }
        private void JournalBtn_Click(object sender, RoutedEventArgs e)
        {
            JournalPage journalPage = new JournalPage();
            MainFrameTeacher.Navigate(journalPage);
        }
        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage = new EmployeePage();
            MainFrameTeacher.Navigate(employeePage);
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeletePage deletePage = new DeletePage();
            MainFrameTeacher.Navigate(deletePage);
        }
    }
}
using MatveevaLearnSpas.AppData;
using MatveevaLearnSpas.View.Pages;
using MatveevaLearnSpas.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatveevaLearnSpas
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestingPage testingPage = new TestingPage();
            MainFrame.Navigate(testingPage);
            FrameHelper.selectedFrame = MainFrame;
        }
        private void TestingBtn_Click(object sender, RoutedEventArgs e)
        {
            TestingPage testingPage = new TestingPage();
            MainFrame.Navigate(testingPage);
        }
        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            AdditionalMaterialPage additionalMaterialPage = new AdditionalMaterialPage();
            MainFrame.Navigate(additionalMaterialPage);
        }
        private void GoOutBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            MainFrame.Navigate(profilePage);
        }
    }
}
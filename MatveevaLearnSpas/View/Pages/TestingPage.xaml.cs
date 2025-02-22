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

namespace MatveevaLearnSpas.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestingPage.xaml
    /// </summary>
    public partial class TestingPage : Page
    {

        public TestingPage()
        {
            InitializeComponent();
            ModulTwoBtn.Visibility = Visibility.Collapsed;
        }

        private void ModulTwoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModulOneBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

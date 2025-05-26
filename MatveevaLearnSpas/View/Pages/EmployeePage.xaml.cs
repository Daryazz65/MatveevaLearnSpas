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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatveevaLearnSpas.View.Pages
{
    public partial class EmployeePage : Page
    {
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public EmployeePage()
        {
            InitializeComponent();
            LoadTestings();
        }
        private void LoadTestings()
        {
            // Важно: Include нужен, если используется EF и ленивые связи
            TestingDG.ItemsSource = _context.Testings
                .Include("User")
                .Include("Section")
                .ToList();
        }
    }
}
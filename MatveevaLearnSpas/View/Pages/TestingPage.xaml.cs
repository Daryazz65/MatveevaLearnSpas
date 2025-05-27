using MatveevaLearnSpas.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatveevaLearnSpas.View.Pages
{
    public partial class TestingPage : Page
    {
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public TestingPage()
        {
            InitializeComponent();
            GenerateModuleButtons();
        }
        private void ModulOneBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введение");
        }
        private void ModulTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 1");
        }
        private void ModulThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 2");
        }
        private void Modul4Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 3");
        }
        private void Modul5Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 4");
        }
        private void Modul6Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 5");
        }
        private void Modul7Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 6");
        }
        private void Modul8Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 7");
        }
        private void Modul9Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 8");
        }
        private void Modul10Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 9");
        }
        private void Modul11Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 10");
        }
        private void Modul12Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 11");
        }
        private void Modul13Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 12");
        }
        private void Modul14Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 13");
        }
        private void Modul15Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 14");
        }
        private void Modul16Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 15");
        }
        private void Modul17Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 16");
        }
        private void Modul18Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лекция 17");
        }
        private void Modul19Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Подведение итогов");
        }
        private void GenerateModuleButtons()
        {
            var stackPanel = this.FindName("ModulesStackPanel") as StackPanel;
            if (stackPanel == null) return;
            stackPanel.Children.Clear();
            var sections = _context.Sections.OrderBy(s => s.Orderr).ToList();
            foreach (var section in sections)
            {
                var grid = new Grid
                {
                    Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#026DD0"),
                    Margin = new Thickness(5),
                    Height = 50
                };
                var button = new Button
                {
                    Content = new TextBlock
                    {
                        Text = section.Name,
                        Foreground = System.Windows.Media.Brushes.White,
                        FontSize = 15
                    },
                    Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#131F24"),
                    BorderBrush = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#293B43"),
                    Margin = new Thickness(5),
                    VerticalAlignment = VerticalAlignment.Center,
                    Tag = section.Id
                };
                button.Click += ModuleBtn_Click;
                grid.Children.Add(button);
                stackPanel.Children.Add(grid);
            }
        }
        private void ModuleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int sectionId)
            {
                NavigationService.Navigate(new TestPage(sectionId));
            }
        }
    }
}
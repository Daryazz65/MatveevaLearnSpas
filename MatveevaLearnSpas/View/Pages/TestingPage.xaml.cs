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
            // Add your logic for Module 1 button click here
            MessageBox.Show("Модуль 1: Введение");
        }

        private void ModulTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 2 button click here
            MessageBox.Show("Модуль 2: Лекция 1");
        }

        private void ModulThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 3 button click here
            MessageBox.Show("Модуль 3: Лекция 2");
        }

        private void Modul4Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 4 button click here
            MessageBox.Show("Модуль 4: Лекция 3");
        }

        private void Modul5Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 5 button click here
            MessageBox.Show("Модуль 5: Лекция 4");
        }

        private void Modul6Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 6 button click here
            MessageBox.Show("Модуль 6: Лекция 5");
        }

        private void Modul7Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 7 button click here
            MessageBox.Show("Модуль 7: Лекция 6");
        }

        private void Modul8Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 8 button click here
            MessageBox.Show("Модуль 8: Лекция 7");
        }

        private void Modul9Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 9 button click here
            MessageBox.Show("Модуль 9: Лекция 8");
        }

        private void Modul10Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 10 button click here
            MessageBox.Show("Модуль 10: Лекция 9");
        }

        private void Modul11Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 11 button click here
            MessageBox.Show("Модуль 11: Лекция 10");
        }

        private void Modul12Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 12 button click here
            MessageBox.Show("Модуль 12: Лекция 11");
        }

        private void Modul13Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 13 button click here
            MessageBox.Show("Модуль 13: Лекция 12");
        }

        private void Modul14Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 14 button click here
            MessageBox.Show("Модуль 14: Лекция 13");
        }

        private void Modul15Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 15 button click here
            MessageBox.Show("Модуль 15: Лекция 14");
        }

        private void Modul16Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 16 button click here
            MessageBox.Show("Модуль 16: Лекция 15");
        }

        private void Modul17Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 17 button click here
            MessageBox.Show("Модуль 17: Лекция 16");
        }

        private void Modul18Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 18 button click here
            MessageBox.Show("Модуль 18: Лекция 17");
        }

        private void Modul19Btn_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for Module 19 button click here
            MessageBox.Show("Модуль 19: Подведение итогов");
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
                // Открыть страницу теста для выбранной лекции
                NavigationService.Navigate(new TestPage(sectionId));
            }
        }
    }
}
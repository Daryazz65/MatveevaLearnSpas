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
    /// <summary>
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public DeletePage()
        {
            InitializeComponent();
            LoadLectures();
        }
        private void LoadLectures()
        {
            LecturesDG.ItemsSource = _context.Sections.OrderBy(s => s.Orderr).ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LecturesDG.SelectedItem is MatveevaLearnSpas.Model.Section selectedSection)
            {
                var controlQuestions = _context.ControlQuestions.Where(cq => cq.IdSection == selectedSection.Id).ToList();
                foreach (var cq in controlQuestions)
                {
                    _context.ControlQuestions.Remove(cq);
                }
                var testings = _context.Testings.Where(t => t.IdSection == selectedSection.Id).ToList();
                foreach (var t in testings)
                {
                    _context.Testings.Remove(t);
                }
                _context.Sections.Remove(selectedSection);
                _context.SaveChanges();
                MessageBox.Show("Лекция удалена.");
                LoadLectures();
            }
            else
            {
                MessageBox.Show("Выберите лекцию для удаления.");
            }
        }
    }
}
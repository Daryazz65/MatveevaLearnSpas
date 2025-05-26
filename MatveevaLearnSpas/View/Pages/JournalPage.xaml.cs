using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public ObservableCollection<QuestionInput> Questions { get; set; } = new ObservableCollection<QuestionInput>();

        public JournalPage()
        {
            InitializeComponent();
            QuestionsDG.ItemsSource = Questions;
        }

        private void AddLectureBtn_Click(object sender, RoutedEventArgs e)
        {
            string lectureName = LectureNameTb.Text?.Trim();
            if (string.IsNullOrWhiteSpace(lectureName))
            {
                MessageBox.Show("Введите название лекции.");
                return;
            }
            if (Questions.Count == 0 || Questions.Any(q => string.IsNullOrWhiteSpace(q.Question) || string.IsNullOrWhiteSpace(q.CorrectAnswer)))
            {
                MessageBox.Show("Добавьте вопросы и заполните все обязательные поля.");
                return;
            }

            // 1. Создать новую лекцию (Section)
            var newSection = new MatveevaLearnSpas.Model.Section
            {
                Name = lectureName,
                Orderr = _context.Sections.Any() ? _context.Sections.Max(s => s.Orderr) + 1 : 1
            };
            _context.Sections.Add(newSection);
            _context.SaveChanges();

            // 2. Добавить вопросы к лекции
            foreach (var q in Questions)
            {
                var question = new ControlQuestion
                {
                    IdSection = newSection.Id,
                    Question = q.Question,
                    CorrectAnswer = q.CorrectAnswer,
                    InCorrectAnswer = q.IncorrectAnswer1,
                    InCorrectAnswerTwo = q.IncorrectAnswer2
                };
                _context.ControlQuestions.Add(question);
            }
            _context.SaveChanges();

            MessageBox.Show("Лекция и тест успешно добавлены!");
            Questions.Clear();
            LectureNameTb.Text = "";
        }
    }

    // Класс для ввода вопросов
    public class QuestionInput
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string IncorrectAnswer1 { get; set; }
        public string IncorrectAnswer2 { get; set; }
    }
}
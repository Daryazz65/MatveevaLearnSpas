using MatveevaLearnSpas.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MatveevaLearnSpas.View.Pages
{
    public partial class ProfilePage : Page
    {
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public ProfilePage()
        {
            InitializeComponent();
            LoadProfile();
        }
        private void LoadProfile()
        {
            var user = App.CurrentUser;
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            FullNameTbl.Text = user.FullName;
            PostTbl.Text = $"Должность: {user.Post?.Name ?? "—"}";
            RoleTbl.Text = $"Роль: {user.Role?.Name ?? "—"}";
            DateRegTbl.Text = $"Дата регистрации: {user.DateRegistration.ToShortDateString()}";

            // Фото
            if (!string.IsNullOrWhiteSpace(user.Photo))
            {
                try
                {
                    PhotoImg.Source = new BitmapImage(new Uri(user.Photo, UriKind.RelativeOrAbsolute));
                }
                catch
                {
                    PhotoImg.Source = null;
                }
            }
            else
            {
                PhotoImg.Source = null;
            }

            // Рейтинг
            var userTestings = _context.Testings.Where(t => t.IdUser == user.Id).ToList();
            int lecturesPassed = userTestings.Count(t => t.Status);
            int totalLectures = _context.Sections.Count(); // Всего лекций в системе

            // Считаем вопросы и ошибки
            int totalQuestions = 0;
            int totalErrors = 0;

            foreach (var testing in userTestings)
            {
                if (testing.Section == null) continue;
                var questions = _context.ControlQuestions.Where(q => q.IdSection == testing.IdSection).ToList();
                totalQuestions += questions.Count;
                // Здесь можно добавить подсчёт ошибок, если есть такая информация
            }

            double avgPercent = totalLectures > 0 ? (lecturesPassed * 100.0 / totalLectures) : 0;

            QuestionsPassedTbl.Text = $"Пройдено вопросов: {totalQuestions}";
            ErrorsTbl.Text = $"Ошибок: {totalErrors}";
            AveragePercentTbl.Text = $"Средний процент прохождения: {avgPercent:F1}%";
            LecturesPassedTbl.Text = $"Пройдено лекций: {lecturesPassed} из {totalLectures}";
        }
    }
}
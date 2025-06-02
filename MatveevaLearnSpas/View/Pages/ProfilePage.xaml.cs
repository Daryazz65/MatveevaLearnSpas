using MatveevaLearnSpas.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using MatveevaLearnSpas.AppData;

namespace MatveevaLearnSpas.View.Pages
{
    public partial class ProfilePage : Page
    {
        private string _photoPath; 
        private MatveevaLearnSpasEntities _context = App.GetContext();
        public ProfilePage()
        {
            InitializeComponent();
            LoadProfile();
            LoadProfilePhoto();
        }
        private void LoadProfile()
        {
            var user = App.CurrentUser;
            if (user == null)
            {
                MessageBoxHelper.Error("Пользователь не найден. Повторите вход в систему.");
                return;
            }
            SetProfileImage(user.Photo);
            FullNameTbl.Text = user.FullName;
            RoleTbl.Text = user.Role?.Name;
            PostTbl.Text = user.Post?.Name;
            var userTestings = _context.Testings.Where(t => t.IdUser == user.Id).ToList();
            int lecturesPassed = userTestings.Count(t => t.Status);
            int totalLectures = _context.Sections.Count();
            int totalQuestions = 0;
            int totalErrors = 0;
            foreach (var testing in userTestings)
            {
                if (testing.Section == null) continue;
                var questions = _context.ControlQuestions.Where(q => q.IdSection == testing.IdSection).ToList();
                totalQuestions += questions.Count;
            }
            double avgPercent = totalLectures > 0 ? (lecturesPassed * 100.0 / totalLectures) : 0;
            QuestionsPassedTbl.Text = $"Пройдено вопросов: {totalQuestions}";
            ErrorsTbl.Text = $"Ошибок: 5";
            AveragePercentTbl.Text = $"Средний процент прохождения: {avgPercent:F1}%";
            LecturesPassedTbl.Text = $"Пройдено лекций: {lecturesPassed} из {totalLectures}";
        }
        private void SetProfileImage(byte[] photoBytes)
        {
            if (photoBytes != null && photoBytes.Length > 0)
            {
                using (var ms = new MemoryStream(photoBytes))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    image.Freeze();
                    PhotoImg.Source = image;
                }
            }
            else
            {
                PhotoImg.Source = null;
            }
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = App.CurrentUser;
            if (user != null)
            {
                user.Photo = null;
                _context.SaveChanges();
                PhotoImg.Source = null;
                MessageBoxHelper.Information("Фото удалено из профиля.");
            }
        }
        private bool IsValidImage(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    return decoder.Frames.Count > 0;
                }
            }
            catch
            {
                return false;
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (!IsValidImage(openFileDialog.FileName))
                {
                    MessageBoxHelper.Error("Выбранный файл не является корректным изображением.");
                    return;
                }
                var user = App.CurrentUser;
                if (user != null)
                {
                    user.Photo = File.ReadAllBytes(openFileDialog.FileName);
                    _context.SaveChanges();
                    SetProfileImage(user.Photo);
                    MessageBoxHelper.Information("Фото успешно добавлено в профиль.");
                }
            }
        }
        private void LoadProfilePhoto()
        {
            if (!string.IsNullOrEmpty(_photoPath) && File.Exists(_photoPath))
            {
                PhotoImg.Source = new BitmapImage(new Uri(_photoPath));
            }
            else
            {
                PhotoImg.Source = null;
            }
        }
    }
}
using MatveevaLearnSpas.AppData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        public TestPage(int moduleId)
        {
            InitializeComponent();
            questions = LoadQuestions(moduleId);
            ShowQuestion();
        }
        private List<Question> LoadQuestions(int moduleId)
        {
            List<Question> questions = new List<Question>();
            string query = "SELECT Id, Question, CorrectAnswer, InCorrectAnswer, InCorrectAnswerTwo FROM ControlQuestion WHERE IdSection = @moduleId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@moduleId", moduleId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                Id = reader.GetInt32(0),
                                Text = reader.GetString(1),
                                CorrectAnswer = reader.GetString(2),
                                IncorrectAnswers = new List<string>
                                {
                                    reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    reader.IsDBNull(4) ? "" : reader.GetString(4)
                                }
                            });
                        }
                    }
                }
            }
            return questions;
        }
        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var question = questions[currentQuestionIndex];
                QuestionTextBlock.Text = question.Text;
                var answers = new List<string>(question.IncorrectAnswers) { question.CorrectAnswer };
                answers = answers.OrderBy(a => Guid.NewGuid()).ToList();
                AnswerBtn1.Content = answers[0];
                AnswerBtn2.Content = answers[1];
                AnswerBtn3.Content = answers[2];
                AnswerBtn1.Visibility = Visibility.Visible;
                AnswerBtn2.Visibility = Visibility.Visible;
                AnswerBtn3.Visibility = Visibility.Visible;
                NextButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBoxHelper.Information($"Тест завершён! Ваш результат: {score} из {questions.Count}");
                NavigationService.GoBack();
            }
        }
        private void AnswerButton1_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            var correctAnswer = questions[currentQuestionIndex].CorrectAnswer;
            if (clickedButton.Content.ToString() == correctAnswer)
            {
                MessageBoxHelper.Information("Правильно!", "Результат");
                score++;
            }
            else
            {
                MessageBoxHelper.Information($"Неверно! Правильный ответ: {correctAnswer}", "Результат");
            }
            NextButton_Click(sender, e);
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            AnswerBtn1.IsEnabled = true;
            AnswerBtn2.IsEnabled = true;
            AnswerBtn3.IsEnabled = true;
            ShowQuestion();
        }
    }
}

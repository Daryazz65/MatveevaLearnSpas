using MatveevaLearnSpas.AppData;
using System;
using System.Collections.Generic;
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
            string query = "SELECT Id, Question, CorrectAnswer, InCorrectAnswer, InCorrectAnswer2 FROM ControlQuestion WHERE IdSection = @moduleId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@moduleId", moduleId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                Id = reader.GetInt32("Id"),
                                Text = reader.GetString("Question"),
                                CorrectAnswer = reader.GetString("CorrectAnswer"),
                                IncorrectAnswers = new List<string>
                            {
                                reader.GetString("InCorrectAnswer"),
                                reader.GetString("InCorrectAnswer2")
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

                // Перемешиваем ответы
                var answers = new List<string>(question.IncorrectAnswers) { question.CorrectAnswer };
                answers = answers.OrderBy(a => Guid.NewGuid()).ToList();

                // Устанавливаем ответы на кнопки
                AnswerBtn1.Content = answers[0];
                AnswerBtn2.Content = answers[1];
                AnswerBtn3.Content = answers[2];

                // Делаем кнопки видимыми
                AnswerBtn1.Visibility = Visibility.Visible;
                AnswerBtn2.Visibility = Visibility.Visible;
                AnswerBtn3.Visibility = Visibility.Visible;

                // Скрываем кнопку "Далее"
                NextButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show($"Тест завершён! Ваш результат: {score} из {questions.Count}");
                NavigationService.GoBack();
            }
        }

        private void AnswerButton1_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            var correctAnswer = questions[currentQuestionIndex].CorrectAnswer;

            if (clickedButton.Content.ToString() == correctAnswer)
            {
                MessageBox.Show("Правильно!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                score++;
            }
            else
            {
                MessageBox.Show($"Неверно! Правильный ответ: {correctAnswer}", "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Показываем кнопку "Далее"
            NextButton.Visibility = Visibility.Visible;

            // Делаем кнопки с ответами неактивными
            AnswerBtn1.IsEnabled = false;
            AnswerBtn2.IsEnabled = false;
            AnswerBtn3.IsEnabled = false;
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

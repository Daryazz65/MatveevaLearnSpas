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
        private string connectionString = "server=localhost;database=yourdb;user=root;password=yourpassword";
        private List<Question> questions;
        private int currentQuestionIndex = 0;

        public TestPage(int moduleId)
        {
            InitializeComponent();
            questions = LoadQuestions(moduleId); // Загружаем вопросы для модуля
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
    }
}

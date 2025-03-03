using System.Configuration;
using MatveevaLearnSpas.AppData;
using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AdminAddPage.xaml
    /// </summary>
    public partial class AdminAddPage : Page
    {
        private static MatveevaLearnSpasEntities _context = App.GetContext();
        private int _selectedUserId;
        private string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        public AdminAddPage()
        {
            InitializeComponent();
            LoadUsers();
            UserDG.ItemsSource = _context.Users.ToList();
            AddRoleCmb.ItemsSource = _context.Roles.ToList();
            EditRoleCmb.ItemsSource = _context.Roles.ToList();
            AddRoleCmb.DisplayMemberPath = "Name";
            EditRoleCmb.DisplayMemberPath = "Name";
            AddPostCmb.ItemsSource = _context.Posts.ToList();
            EditPostCmb.ItemsSource = _context.Posts.ToList();
            AddPostCmb.DisplayMemberPath = "Name";
            EditPostCmb.DisplayMemberPath = "Name";
        }

        private void GetUsers()
        {
            UserDG.ItemsSource = _context.Users.ToList();

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AddNameTbl.Text) && !string.IsNullOrEmpty(AddLoginBtn.Text) 
                && !string.IsNullOrEmpty(AddPasswordBtn.Text) && AddRoleCmb.SelectedItem != null 
                && AddDateRegistrDp.SelectedDate != null)
            {
                User newUser = new User()
                {
                    FullName = AddNameTbl.Text,
                    Role = AddRoleCmb.SelectedItem as Role,
                    Post = AddPostCmb.SelectedItem as Post,
                    DateRegistration = (DateTime)AddDateRegistrDp.SelectedDate,
                    Login = AddLoginBtn.Text,
                    Password = AddPasswordBtn.Text
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                GetUsers();
                MessageBoxHelper.Information("Сотрудник добавлен.");
            }
            else
            {
                MessageBoxHelper.Error("Не все данные были введены!");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var productToDelete = (sender as FrameworkElement).DataContext as User;
            _context.Users.Remove(productToDelete);
            _context.SaveChanges();
            GetUsers();
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Выберите пользователя для редактирования.");
                return;
            }

            string newFullName = txtFullName.Text;
            string newRole = EditRoleCmb.SelectedItem?.ToString();
            string newPost = EditPostCmb.SelectedItem?.ToString();
            string newLogin = txtLogin.Text;
            string newPassword = txtPassword.Text;
            DateTime? newRegDate = EditDateRegistrDp.SelectedDate;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE [User] SET FullName = @FullName, IdRole = @Role, IdPost = @Post, " +
                    "Login = @Login, Password = @Password, DateRegistration = @RegDate WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", newFullName);
                    cmd.Parameters.AddWithValue("@Role", newRole);
                    cmd.Parameters.AddWithValue("@Post", newPost);
                    cmd.Parameters.AddWithValue("@Login", newLogin);
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@RegDate", newRegDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", _selectedUserId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные обновлены!");
                        LoadUsers(); // Обновление DataGrid
                    }
                    else
                    {
                        MessageBox.Show("Ошибка обновления.");
                    }
                }
            }
        }
        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM [User]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                UserDG.ItemsSource = dt.DefaultView;
            }
        }
        private void UserDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDG.SelectedItem is User selectedUser)
            {
                txtFullName.Text = selectedUser.FullName;
                EditRoleCmb.SelectedItem = selectedUser.Role;
                EditPostCmb.SelectedItem = selectedUser.Post;
                txtLogin.Text = selectedUser.Login;
                txtPassword.Text = selectedUser.Password;
                EditDateRegistrDp.SelectedDate = selectedUser.DateRegistration;

                // Сохраняем ID редактируемого пользователя
                _selectedUserId = selectedUser.Id;
            }
        }
    }
}

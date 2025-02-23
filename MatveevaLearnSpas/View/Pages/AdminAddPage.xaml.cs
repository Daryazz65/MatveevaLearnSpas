using MatveevaLearnSpas.AppData;
using MatveevaLearnSpas.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
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
        public AdminAddPage()
        {
            InitializeComponent();
            UserDG.ItemsSource = _context.Users.ToList();
            AddRoleCmb.ItemsSource = _context.Roles.ToList();
            AddRoleCmb.DisplayMemberPath = "Name";
            AddPostCmb.ItemsSource = _context.Posts.ToList();
            AddPostCmb.DisplayMemberPath = "Name";
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
            
        }
    }
}

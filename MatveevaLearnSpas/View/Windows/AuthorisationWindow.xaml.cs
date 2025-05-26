﻿using MatveevaLearnSpas.AppData;
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
using System.Windows.Shapes;

namespace MatveevaLearnSpas.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private bool _isCaptchaVerified = false;
        public AuthorisationWindow()
        {
            InitializeComponent();
        }
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text;
            string password = PasswordTb.Password;

            if (AuthorisationHelper.Authorise(login, password))
            {
                User user = AuthorisationHelper.selectedUser;
                // Проверяем роль пользователя
                if (user.Role != null && user.Role.Name.Trim() == "Сис.админ")
                {
                    // Открываем окно/страницу для администратора
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else if (user.Role != null && user.Role.Name.Trim() == "Преподаватель")
                {
                    // Открываем окно/страницу для преподавателя
                    MainWindowTeacher mainWindowTeacher = new MainWindowTeacher();
                    mainWindowTeacher.MainFrameTeacher.Navigate(new View.Pages.JournalPage());
                    mainWindowTeacher.Show();
                    this.Close();
                }
                else
                {
                    // Открываем окно/страницу для обычного сотрудника
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
        }

        private void PasswordRecoveryBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxHelper.Information("Обратитесь к системному администратору.");
        }

        private void CaptchaBtn_Click(object sender, RoutedEventArgs e)
        {
            CaptchaWindow captchaWindow = new CaptchaWindow();
            if (captchaWindow.ShowDialog() == true && captchaWindow.IsVerified)
            {
                _isCaptchaVerified = true;
                MessageBoxHelper.Information("Капча пройдена успешно.");
            }
            else
            {
                _isCaptchaVerified = false;
                MessageBoxHelper.Information("Капча не пройдена.");
            }
        }
    }
}
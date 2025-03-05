﻿using MatveevaLearnSpas.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatveevaLearnSpas.AppData
{
    internal class AuthorisationHelper
    {
        private static MatveevaLearnSpasEntities _context = App.GetContext();
        public static User selectedUser;
        /// <summary>
        /// Авторизует пользователя.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Authorise(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBoxHelper.Error("Не все поля для ввода были заполнены.");
                return false;
            }
            selectedUser = _context.Users.FirstOrDefault(user => user.Login == login && user.Password == password);
            if (selectedUser != null)
            {
                App.CurrentUser = selectedUser;
                return true;
            }
            else
            {
                MessageBoxHelper.Error("Неправильно введен логин или пароль.");
                return false;
            }
        }
    }
}
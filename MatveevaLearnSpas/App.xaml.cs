using MatveevaLearnSpas.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MatveevaLearnSpas
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User CurrentUser { get; set; }
        private static MatveevaLearnSpasEntities _context;
        public static MatveevaLearnSpasEntities GetContext()
        {
            if (_context == null)
            {
                _context = new MatveevaLearnSpasEntities();
            }
            return _context;
        }
    }
}
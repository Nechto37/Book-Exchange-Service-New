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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Сервис_по_обмену_книгами.ViewModels;
using Сервис_по_обмену_книгами.Views;
using Сервис_по_обмену_книгами.Models;

namespace Сервис_по_обмену_книгами
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindowViewModel mv;
        public MainWindow()
        {
            InitializeComponent();

            mv = new MainWindowViewModel();

            DataContext = mv;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mv.CurrentUser != null)
            {
                mv.CurrentUser = null;
                mv.UpperLabel = "Вы вошли как: гость";
                mv.LogIn = "Войти";
                mv.Wishes = null;
                mv.Offers = null;
            }
            else
            {
                Login loginwindow = new Login(mv);
                loginwindow.ShowDialog();
            }
        }
    }
}

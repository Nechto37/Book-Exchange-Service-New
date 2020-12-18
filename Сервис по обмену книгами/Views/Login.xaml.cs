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
using Сервис_по_обмену_книгами.ViewModels;

namespace Сервис_по_обмену_книгами.Views
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public MainWindowViewModel mv;
        public Login(MainWindowViewModel mv)
        {
            InitializeComponent();

            this.mv = mv;

            DataContext = new LoginViewModel(mv);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /*if (mv.CurrentUser != null) */this.DialogResult = true;
        }
    }
}

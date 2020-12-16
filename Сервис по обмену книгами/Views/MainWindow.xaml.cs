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
using Сервис_по_обмену_книгами.Models;

namespace Сервис_по_обмену_книгами
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //public List<Genre> Genres { get; set; }
        //public BooksGrid;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

       //BookExchangeDatabase db = new BookExchangeDatabase();
       //     Genres = db.Genre.ToList();

       // CB.ItemsSource = Genres;

       //     int a = 5;
        }

    }
}

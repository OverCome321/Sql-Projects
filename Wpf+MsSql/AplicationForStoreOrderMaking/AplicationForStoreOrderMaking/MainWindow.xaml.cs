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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using AplicationForStoreOrderMaking.Pages1;
namespace AplicationForStoreOrderMaking
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateOrderBut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateOrder());
        }

        private void ChangeOrdersBut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new YourOrders());
        }
    }
}

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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {
            if(TextBox1.Text=="" && TextBox2.Text=="")
            {
                string msg = "Мінімум одне поле повинно містити текст!";
                MessageBoxResult result =
                MessageBox.Show(msg,
                "Помилка",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
            else
            {
                string temp = TextBox1.Text;
                TextBox1.Text = TextBox2.Text;
                TextBox2.Text = temp;
            }
           
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            string msg = "Ви впевнені?";
            MessageBoxResult result =
            MessageBox.Show(msg,
            "Вихід",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Question);
            if(result == MessageBoxResult.OK) 
            {
                Environment.Exit(0);
            }
        }
    }
}

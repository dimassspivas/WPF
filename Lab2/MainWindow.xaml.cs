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
using System.Windows.Threading;

namespace Lab2
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

        public void ProgressBar1Update(Array sender, ArrayEventArgs e)
        {
            Dispatcher.Invoke(() => { PrBar1.Value = (e.Iteration * 100 / sender.Length); });
        }

        public void ProgressBar2Update(Array sender, ArrayEventArgs e)
        {
            Dispatcher.Invoke(() => { PrBar2.Value = (e.Iteration * 100 / sender.Length); });
        }

        private void Button_Click_Stop1(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click_Stop2(object sender, RoutedEventArgs e)
        {
            
        }

       
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            Array arr1 = new Array(10000, ProgressBar1Update);
            Array arr2 = new Array(15000, ProgressBar2Update);
            arr1.PercantageChange += ProgressBar1Update;
            arr2.PercantageChange += ProgressBar2Update;
            arr1.SortAsync();
            arr2.SortDescAsync();

        }
    }
    
}

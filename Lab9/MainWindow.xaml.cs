using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace CommandOrderDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Order> Orders = new ObservableCollection<Order>();
        public MainWindow()
        {
            InitializeComponent();
            lbxOrders.ItemsSource = Orders;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "Data (*.xml, *.dat)|*xml;*.dat|" +
                         "All files (*.*)|*.*";
            if (odf.ShowDialog() != true)
            {
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Order>));
            using (TextReader rs = new StreamReader(odf.FileName))
            {
                Orders = serializer.Deserialize(rs) as ObservableCollection<Order>;
                lbxOrders.ItemsSource = Orders;
            }
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "Data (*.xml, *.dat)|*xml;*.dat|" +
                         "All files (*.*)|*.*";
            if (sdf.ShowDialog() != true)
            {
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Order>));
            using (TextWriter ws = new StreamWriter(sdf.FileName))
            {
                serializer.Serialize(ws, Orders);
            }
        }

        public void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void InsertCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Orders.Add(new Order("New Customer", 0, DateTime.Now));
        }

        private void InsertCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Orders.Remove((Order)lbxOrders.SelectedItem);
        }

        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Orders.Count > 0;
        }

    }

}

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

namespace ObservableDemo01
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Orders.Add(new Order("New Customer", 0, DateTime.Now));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbxOrders.SelectedItem != null)
            {
                Orders.Remove((Order)lbxOrders.SelectedItem);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
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
    }
}

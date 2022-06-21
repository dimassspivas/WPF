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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab7
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

        public bool IsFilled()
        {
            return Sender.Text != "" && Recipient.Text != "" && Amount.Text != "";
        }
        public void Fill(BankPayment payment)
        {
            Sender.Text = payment.Sender;
            Recipient.Text = payment.Repicient;
            Amount.Text = payment.Amount.ToString();
            Purpose.Text = payment.PurposeOfPayment;
            StBarText.Text = "Дата створення платежу: "+ payment.CreationDate.ToString();


        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (IsFilled())
            {
                
                BankPayment payment = new BankPayment(Sender.Text,
                                                      Recipient.Text,
                                                      double.Parse(Amount.Text),
                                                      Purpose.Text);
                StBarText.Text = "Дата створення платежу: " + payment.CreationDate.ToString();
                
                if (ComboBoxFormat.SelectionBoxItem.ToString() == "BIN")
                {
                    
                    Serializer.SerializeToBIN(payment);
                }
               else if (ComboBoxFormat.SelectionBoxItem.ToString() == "XML")
                {
                    Serializer.SerializeToXML(payment);
                }
                

            }
            else
            {
                MessageBox.Show("Заповніть усі поля!","Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Amount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Regex regex = new Regex(@"[^\d.]"); 
            if (regex.IsMatch(Amount.Text))
            {
                MessageBox.Show("Введіть число!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Amount.Clear();
            }
        }
        private void Button_Click_Upload(object sender, RoutedEventArgs e)
        {
            if (Serializer.dialog.ShowDialog().Value)
            {
                if (Path.GetExtension(Serializer.dialog.FileName) == ".dat")
                {

                    BankPayment bp = Serializer.DeserializeFromBIN();
                    if (bp != null)
                    {
                        Fill(bp);
                    }
                }
                else if (Path.GetExtension(Serializer.dialog.FileName) == ".xml")
                {
                    BankPayment bp = Serializer.DeserializeFromXML();
                    if (bp != null)
                    {
                        Fill(bp);
                    }
                }
            }
              
            
            
        }

    }
}

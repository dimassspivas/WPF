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
using Microsoft.Win32;
using System.IO;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        List<Image> imgList = new List<Image>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Graphic Files| *.bmp; *.png; *.gif; *.jpg; *.ico";
            if (dialog.ShowDialog().Value)
            {
                
                
                Image img = new Image(dialog.SafeFileName, dialog.FileName, new BitmapImage(new Uri(dialog.FileName)));
                Image.Source = img.Img;
                StBarTextBlock.Text = "Path: " + img.Path;
                imgList.Add(img);
                ListBox.Items.Add(img.Name);
                
                
            }
        }
        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            Image.Source = null;
            StBarTextBlock.Text = "";
        }

       
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image.Source = imgList[ListBox.SelectedIndex].Img;
            StBarTextBlock.Text = "Path: " + imgList[ListBox.SelectedIndex].Path;

        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            string msg = "Ви впевнені?";
            MessageBoxResult result =
            MessageBox.Show(msg,
            "Вихід",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void MenuItem_Click_Clear(object sender, RoutedEventArgs e)
        {
            Image.Source = null;
            StBarTextBlock.Text = "";
            imgList.Clear();
            ListBox.Items.Clear();
        }
    }
}

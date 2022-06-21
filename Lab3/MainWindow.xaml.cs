using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Net;
using System.Threading;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Downloader downloader;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TxtLink_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex urlRegex = new Regex(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");
            if (urlRegex.IsMatch(TxtLink.Text))
                DownloadStart.IsEnabled = true;
            else
                DownloadStart.IsEnabled = false;
        }
        public void ProgressBarUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                PrBar.Value = e.ProgressPercentage;
                TxtPercent.Text = $"Downloaded: {e.ProgressPercentage.ToString()}%";
                TxtSize.Text = $"{(long)e.BytesReceived/ 1048576} / {e.TotalBytesToReceive/ 1048576} MB" ;

            });
        }

        private async void DownloadStart_Click_Start(object sender, RoutedEventArgs e)
        {
            DownloadStart.IsEnabled = false;
            DownloadStop.IsEnabled = true;
            downloader = new Downloader(TxtLink.Text, ProgressBarUpdate);
            SaveFileDialog sfd = new SaveFileDialog();

            if (ComboBoxType.SelectedIndex == 0)
            {
                sfd.FileName = downloader.GetInfo();
                
                if (sfd.ShowDialog().Value)
                {
                    downloader.FileName = sfd.FileName;
                    Path.Text = $"Path to download: {sfd.FileName}";
                    bool t = await downloader.DownloadFileAsync();
                    if (t)
                    {
                        DownloadStart.IsEnabled = true;
                    }
                }
                else
                {
                    DownloadStart.IsEnabled = true;
                }
               

            }
            else if (ComboBoxType.SelectedIndex == 1)
            {
                sfd.FileName = "index.html";
                if (sfd.ShowDialog().Value)
                {
                    downloader.FileName = sfd.FileName;
                    Path.Text = $"Path to download: {sfd.FileName}";
                    if (await downloader.DownloadPageAsync())
                    {
                        PrBar.Value = 100;
                        TxtPercent.Text = $"Downloaded: 100%";
                        DownloadStart.IsEnabled = true;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DownloadStart.IsEnabled = true;
            }
           

        }

        private void DownloadStop_Click_Stop(object sender, RoutedEventArgs e)
        {
            downloader.StopDownload();
        }
    }
}

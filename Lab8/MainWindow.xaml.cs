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
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path = "";
        public bool FileIsOpen = false;
        public bool FileIsSave = false;
        public bool FileIsPrint = false;
        
        public MainWindow()
        {
            InitializeComponent();
            SaveButton.IsEnabled = false;
            SaveAsButton.IsEnabled = false;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog().Value)
            {
                FileIsOpen = true;
                FileIsSave = true;
                FileIsPrint = false;
                Path = openFileDialog.FileName;
                Text.Text = File.ReadAllText(Path);
                SaveAsButton.IsEnabled = Text.Text != "";
                FileName.Text ="File name: " +  openFileDialog.SafeFileName;



            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(Path, Text.Text);
            FileIsSave = true;
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            if (saveFileDialog.ShowDialog().Value)
            {
                Path = saveFileDialog.FileName;
                File.WriteAllText(Path, Text.Text);
                FileIsSave = true;
                FileName.Text = "File name: " + saveFileDialog.SafeFileName;


            }

        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FileIsPrint)
            {
                if (FileIsOpen)
                {
                    SaveButton.IsEnabled = true;
                }
                SaveAsButton.IsEnabled = Text.Text != "";
                FileIsSave = false;
            }
            FileIsPrint = true;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (Text.Text!="" && !FileIsSave)
            {
                
                string msg = "Do you want save changes?";
                MessageBoxResult result =
                  MessageBox.Show(
                    
                    msg,
                    "Text Editor",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (FileIsOpen)
                    {
                        File.WriteAllText(Path, Text.Text);
                        e.Cancel = false;
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        if (saveFileDialog.ShowDialog().Value)
                        {
                            File.WriteAllText(saveFileDialog.FileName, Text.Text);
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                   
                   
                }
                else if (result == MessageBoxResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }




            }
        }

        private void Text_KeyUp(object sender, KeyEventArgs e)
        {
            var index = Text.CaretIndex;
            var row = Text.GetLineIndexFromCharacterIndex(index);
            var col = index - Text.GetCharacterIndexFromLineIndex(row);
            

            Cursor.Text = string.Format("Line: {0}, Col: {1}", row + 1, col + 1);


        }

        private void Text_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = Text.CaretIndex;
            var row = Text.GetLineIndexFromCharacterIndex(index);
            var col = index - Text.GetCharacterIndexFromLineIndex(row);


            Cursor.Text = string.Format("Line: {0}, Col: {1}", row + 1, col + 1);
        }
    }
}

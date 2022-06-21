using SharedResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileBrowser.ViewModel
{
    public class MainViewModel: AbstractObservableViewModel
    {
        public MainViewModel()
        {
            LeftContent = new TreeViewModel<FolderTreeItem>();
            InitLeftContent();
        }

        public TreeViewModel<FolderTreeItem> LeftContent { get; private set; }

        private void InitLeftContent()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var driveInfo in drives)
            {
                LeftContent.Add(
                    new FolderTreeItem(
                        driveInfo.Name, 
                        driveInfo.DriveType == System.IO.DriveType.Fixed,
                        driveInfo.DriveType == System.IO.DriveType.Removable,
                        driveInfo.DriveType == System.IO.DriveType.CDRom
                    ),
                    GetDriveDirectories(driveInfo.Name)
                );
            }
        }

        private ObservableCollection<TreeItemViewModel<FolderTreeItem>> GetDriveDirectories(string path)
        {
            ObservableCollection<TreeItemViewModel<FolderTreeItem>> result = new ObservableCollection<TreeItemViewModel<FolderTreeItem>>();
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    result.Add(
                        new TreeItemViewModel<FolderTreeItem>() { Data = new FolderTreeItem(dir) }
                    );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return result;
        }

    }
}

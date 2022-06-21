using SharedResources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.ViewModel
{
    [Serializable]
    public class FolderTreeItem: AbstractObservableViewModel
    {
        public FolderTreeItem(string name, bool isDrive = false, bool isFloppy = false, bool isCD = false)
        {
            Name = name;
            IsDrive = isDrive;
            IsFloppy = isFloppy;
            IsCD = isCD;
        }

        public string Name { get; }
        
        public string ShortName
        { 
            get
            {
                var result = Path.GetFileName(Name);
                if (result.Length == 0 || result == "")
                {
                    return Name;
                }
                return result;
            }
        }

        public bool IsFolder { get => !IsDrive && !IsFloppy && !IsCD;  }
        
        public bool IsDrive { get; private set; }
        
        public bool IsFloppy { get; private set; }
        
        public bool IsCD { get; private set; }
        
        public bool Expanded { get; set; } = false;

        public string ImageUri
        {
            get
            {
                const string resourceRoot = "pack://application:,,,/Resources/tree/{0}";
                var icon = "";
                if (IsFolder)
                {
                    icon = Expanded ? "FolderOpened_16x.png" : "FolderClosed_16x.png";
                    
                } else if (IsFloppy)
                {
                    icon = "FloppyDrive_16x.png";
                }
                else if (IsCD)
                {
                    icon = "CD_16x.png";
                } else if (IsDrive)
                {
                    icon = "FloppyDrive_16x.png";
                }

                return string.Format(resourceRoot, icon);
            }
        }
    }
}

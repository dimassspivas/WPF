using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab6
{
    class Image
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public BitmapImage Img {get; set;}
        public Image(string name, string path, BitmapImage img) 
        {
            Name = name;
            Path = path;
            Img = img;
        }


    }
}

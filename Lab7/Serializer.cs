using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Lab7
{
    public static class Serializer
    {
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(BankPayment));
        public static BinaryFormatter formatter = new BinaryFormatter();
        public static BankPayment Payment { get; set; }
        public static OpenFileDialog dialog = new OpenFileDialog
        {
            Filter = "Files (.dat; .xml)|*.dat; *.xml|Binary Files (.dat) | *.dat| XML Files (.xml)| *.xml"
        };
        public static bool SerializeToBIN(BankPayment bp)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = ".dat",
                Filter = "Binary Files| *.dat"
            };
            if (dialog.ShowDialog().Value)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, bp);
                    return true;
                }
            }
            else
            {
                return false;
            }

        }
        public static bool SerializeToXML(BankPayment bp)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = ".xml",
                Filter = "XML Files| *.xml"
            };
            if (dialog.ShowDialog().Value)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, bp);
                    return true;
                }
            }
            else
            {
                return false;
            }

           
        }
        public static BankPayment DeserializeFromBIN()
        {
            using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
            {
                BankPayment bp = (BankPayment)formatter.Deserialize(fs);
                return bp;
            }

        }
        public static BankPayment DeserializeFromXML()
        {
            using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
            {
                BankPayment bp = (BankPayment)xmlSerializer.Deserialize(fs);
                return bp;
            }

        }

    }
}

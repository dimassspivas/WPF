using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab3
{
    public class Downloader
    {
        public Uri Address { get; set; }
        public WebClient WebClient { get; set; }
        public DownloadProgressChangedEventHandler ProgressChanged;
        public string FileName { get; set; }

        public  Downloader(string address, DownloadProgressChangedEventHandler handler)
        {
            WebClient = new WebClient();
            Address = new Uri(address);
            ProgressChanged = handler;
            
        }
        public async Task<bool> DownloadFileAsync()
        {
            await Task.Run(() => {
                WebClient.DownloadProgressChanged += ProgressChanged;
                WebClient.DownloadFileAsync(Address, FileName);
            });
            return true;
        }
        public void StopDownload()
        {
            WebClient.CancelAsync();
        }
        public string GetInfo()
        {
            
            using (WebClient = new WebClient()) 
            {
                
                try
                {
                    WebClient.OpenRead(Address);
                    var header_contentDisposition = WebClient.ResponseHeaders["content-disposition"];

                    string filename = new ContentDisposition(header_contentDisposition).FileName;
                    return filename;
                }
                catch
                {
                    return "file.dat";
                }

                
            }
            
        }
        public async Task<bool> DownloadPageAsync()
        {
            await Task.Run(() =>
            {
                string html = WebClient.DownloadString(Address);
                File.WriteAllText(FileName, html, Encoding.UTF8);
            });
            return true;
        }
        
        
    }
}

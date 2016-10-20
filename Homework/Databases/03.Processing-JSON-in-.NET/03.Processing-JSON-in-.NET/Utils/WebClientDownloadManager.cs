using System.Net;

using ProcessingJSON.Contracts;

namespace ProcessingJSON.Utils
{
    public class WebClientDownloadManager : IDownloadManager
    {
        public void DownloadFile(string fileUrl, string downloadFolder)
        {
            var client = new WebClient();
            client.DownloadFile(fileUrl, downloadFolder);
        }
    }
}
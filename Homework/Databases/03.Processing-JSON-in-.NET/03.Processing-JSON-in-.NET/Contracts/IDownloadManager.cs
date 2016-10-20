namespace ProcessingJSON.Contracts
{
    public interface IDownloadManager
    {
        void DownloadFile(string fileUrl, string downloadFolder);
    }
}
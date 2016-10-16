namespace XMLProcessing.Root.Commands
{
    using System;
    using System.IO;

    using Contracts;

    internal class ExtractFolderInfoToXmlCommand : ICommand
    {
        public string Execute(string folderUrl)
        {
            var filesInDirectory = Directory.GetFiles(folderUrl);
            var foldersInDirectory = Directory.GetDirectories(folderUrl);

            foreach (var el in foldersInDirectory)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine("------------");

            foreach (var el in filesInDirectory)
            {
                Console.WriteLine(el);
            }

            return "";
        }
    }
}
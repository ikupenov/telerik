namespace XMLProcessing.Root.Commands
{
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    using Contracts;

    internal class ExtractFolderInfoToXmlCommand : ICommand
    {
        public string Execute(string parameters)
        {
            var splitParameters = parameters.Split(',');
            var folderUrl = splitParameters[0].Trim();
            var destinationUrl = splitParameters[0].Trim();

            var filesInDirectory = Directory.GetFiles(folderUrl);
            var foldersInDirectory = Directory.GetDirectories(folderUrl);

            var xDoc = new XDocument();
            var xRoot = new XElement("root");
            xDoc.Add(xRoot);

            var filesElement = new XElement("files");
            foreach (var fileUrl in filesInDirectory)
            {
                var lastSeparator = fileUrl.LastIndexOf("\\");
                var fileName = fileUrl.Substring(lastSeparator + 1);

                filesElement.Add(new XElement("file", fileName));
            }
            xRoot.Add(filesElement);

            var directoriesElement = new XElement("directories");
            foreach (var folder in foldersInDirectory)
            {
                var lastSeparator = folder.LastIndexOf("\\");
                var folderName = folder.Substring(lastSeparator + 1);

                directoriesElement.Add(new XElement("dir", folderName));
            }
            xRoot.Add(directoriesElement);

            xDoc.Save(destinationUrl + "\\dir-info.xml");

            // using XmlWriter:
            //var writerSettings = new XmlWriterSettings();
            //writerSettings.Indent = true;

            //using (var writer = XmlWriter.Create(destinationUrl + "\\dir-info.xml", writerSettings))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("root");

            //    writer.WriteStartElement("files");
            //    foreach (var fileUrl in filesInDirectory)
            //    {
            //        var lastSeparator = fileUrl.LastIndexOf("\\");
            //        var fileName = fileUrl.Substring(lastSeparator + 1);

            //        writer.WriteStartElement("file");
            //        writer.WriteValue(fileName);
            //        writer.WriteEndElement();
            //    }
            //    writer.WriteEndElement();

            //    writer.WriteStartElement("directories");
            //    foreach (var folder in foldersInDirectory)
            //    {
            //        var lastSeparator = folder.LastIndexOf("\\");
            //        var folderName = folder.Substring(lastSeparator + 1);

            //        writer.WriteStartElement("dir");
            //        writer.WriteValue(folderName);
            //        writer.WriteEndElement();
            //    }
            //    writer.WriteEndElement();

            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}

            var output = "File info was successfully extracted.";
            return output;
        }
    }
}
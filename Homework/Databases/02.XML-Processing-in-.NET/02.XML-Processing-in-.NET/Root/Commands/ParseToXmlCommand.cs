namespace XMLProcessing.Root.Commands
{
    using System.IO;
    using System.Xml.Linq;

    using Contracts;

    internal class ParseToXmlCommand : ICommand
    {
        public string Execute(string fileUrl)
        {
            var xDoc = new XDocument();
            var xRoot = new XElement("root");
            xDoc.Add(xRoot);

            using (var reader = new StreamReader(fileUrl))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var splitLine = line.Split(':');
                    var tagName = splitLine[0].Trim();
                    var tagValue = splitLine[1].Trim();

                    var elementToAdd = new XElement(tagName, tagValue);
                    xRoot.Add(elementToAdd);

                    line = reader.ReadLine();
                }
            }

            var extensionSeparatorIndex = fileUrl.LastIndexOf(".");
            var newFileUrl = fileUrl.Substring(0, extensionSeparatorIndex) + ".xml";

            xDoc.Save(newFileUrl);

            var output = "The file was parsed successfully.";
            return output;
        }
    }   
}
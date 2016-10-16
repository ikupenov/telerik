namespace XMLProcessing.Root.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    using Contracts;

    internal class ExtractTagCommand : ICommand
    {
        public string Execute(string parameters)
        {
            var splitParameters = parameters.Split(',');
            var url = splitParameters[0].Trim();
            var elementToExtract = splitParameters[1].Trim();

            ICollection<string> elementsFound = new LinkedList<string>();

            var xmlDoc = XDocument.Load(url);

            xmlDoc.Descendants()
                .Where(x => x.Name == elementToExtract)
                .ToList()
                .ForEach(x => elementsFound.Add(x.Value.ToString()));

            //using (var reader = XmlReader.Create(url))
            //{
            //    while (reader.Read())
            //    {
            //        var isXmlElement = reader.NodeType == XmlNodeType.Element;
            //        var isSearchedElement = reader.Name == elementToExtract;

            //        if (isXmlElement && isSearchedElement)
            //        {
            //            //var value = reader.ReadElementContentAsString();
            //            var value = reader.ReadInnerXml().Trim();
            //            elementsFound.Add(value);
            //        }
            //    }
            //}

            var output = string.Join(", ", elementsFound);
            return output;
        }
    }
}
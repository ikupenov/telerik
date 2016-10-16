namespace XMLProcessing.Root.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;

    using Contracts;

    internal class DeleteAlbumsCommand : ICommand
    {
        public string Execute(string parameters)
        {
            var splitParameters = parameters.Split(',');
            var url = splitParameters[0].Trim();
            var maxPrice = double.Parse(splitParameters[1].Trim());

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var rootElement = xmlDoc.DocumentElement;
            var priceElements = xmlDoc.GetElementsByTagName("price");

            IList elementsToRemove = new List<XmlElement>();

            foreach (XmlElement element in priceElements)
            {
                var price = double.Parse(element.InnerText);
                if (price > maxPrice)
                {
                    elementsToRemove.Add(element);
                }
            }

            foreach (XmlElement element in elementsToRemove)
            {
                rootElement.RemoveChild(element.ParentNode);
            }

            xmlDoc.Save($@"{url}\..\catalogue-new.xml");

            var output = $"Successfully removed all elements with price greater than {maxPrice}.";
            return output;
        }
    }
}
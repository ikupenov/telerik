using System.Xml.Serialization;

namespace Bookstore.Client.XmlModels
{
    public class AuthorXmlElement
    {
        [XmlText]
        public string Name { get; set; }
    }
}
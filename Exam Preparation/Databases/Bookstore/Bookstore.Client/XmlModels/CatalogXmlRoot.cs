using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bookstore.Client.XmlModels
{
    [XmlRoot("catalog")]
    public class CatalogXmlRoot
    {
        [XmlElement("book")]
        public List<BookXmlElement> Books { get; set; }
    }
}
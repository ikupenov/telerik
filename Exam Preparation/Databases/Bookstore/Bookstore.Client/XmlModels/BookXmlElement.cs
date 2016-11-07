using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bookstore.Client.XmlModels
{
    public class BookXmlElement
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlArray("authors")]
        [XmlArrayItem("author")]
        public List<AuthorXmlElement> Author { get; set; }

        [XmlElement("web-site")]
        public string Website { get; set; }

        [XmlArray("reviews")]
        [XmlArrayItem("review")]
        public List<ReviewXmlElement> Reviews { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
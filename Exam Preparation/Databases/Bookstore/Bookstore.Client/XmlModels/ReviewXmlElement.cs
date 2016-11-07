using System;
using System.Xml.Serialization;

namespace Bookstore.Client.XmlModels
{
    public class ReviewXmlElement
    {
        private DateTime postDateTime;

        public ReviewXmlElement()
        {
            this.postDateTime = DateTime.Now;
        }

        [XmlAttribute("author")]
        public string Author { get; set; }

        [XmlIgnore]
        public DateTime PostDate
        {
            get { return this.postDateTime; }
            set { this.postDateTime = value; }
        }

        [XmlAttribute("date")]
        public string PostDateAsString
        {
            get
            {
                return this.PostDate.ToString();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.PostDate = DateTime.Now;
                }
                else
                {
                    this.PostDate = DateTime.Parse(value);
                }
            }
        }

        [XmlText]
        public string Text { get; set; }
    }
}
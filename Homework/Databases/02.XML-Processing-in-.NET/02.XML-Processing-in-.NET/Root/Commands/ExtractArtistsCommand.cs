namespace XMLProcessing.Root.Commands
{
    using System.Collections;
    using System.Text;
    using System.Xml;

    using Contracts;

    internal class ExtractArtistsCommand : ICommand
    {
        public string Execute(string fileUrl)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileUrl);

            // Using XPath:
            // var xPathQuery = "/catalogue/album/artist";
            // var artists = xmlDoc.SelectNodes(xPathQuery);

            var artists = xmlDoc.GetElementsByTagName("artist");
            var artistAlbums = new Hashtable();

            foreach (XmlElement artist in artists)
            {
                if (!artistAlbums.ContainsKey(artist.InnerText))
                {
                    artistAlbums.Add(artist.InnerText, 1);
                }
                else
                {
                    var oldValue = (int)artistAlbums[artist.InnerText];
                    artistAlbums[artist.InnerText] = oldValue + 1;
                }
            }

            var builder = new StringBuilder();
            foreach (DictionaryEntry artistAlbum in artistAlbums)
            {
                var value = (int)artistAlbum.Value == 1 ? "album" : "albums";
                builder.AppendLine($"{artistAlbum.Key} has {artistAlbum.Value} {value}");
            }

            var output = builder.ToString().Trim();
            return output;
        }
    }
}
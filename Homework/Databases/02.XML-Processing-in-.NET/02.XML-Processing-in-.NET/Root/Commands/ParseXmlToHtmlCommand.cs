namespace XMLProcessing.Root.Commands
{
    using System.Xml.Xsl;

    using Contracts;

    internal class ParseXmlToHtmlCommand : ICommand
    {
        public string Execute(string parameters)
        {
            var splitParameters = parameters.Split(',');
            var xmlUrl = splitParameters[0].Trim();
            var xslUrl = splitParameters[1].Trim();

            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(xslUrl);

            var extensionSeparatorIndex = xmlUrl.LastIndexOf('.');
            var htmlUrl = xmlUrl.Substring(0, extensionSeparatorIndex) + ".html";

            xsl.Transform(xmlUrl, htmlUrl);

            var output = "The file was parsed successfully";
            return output;
        }
    }
}
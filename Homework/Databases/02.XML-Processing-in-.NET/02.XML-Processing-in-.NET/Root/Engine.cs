namespace XMLProcessing.Root
{
    using System;

    using Contracts;

    internal sealed class Engine
    {
        private const string QuitCommand = "Quit";

        private static Engine instance = null;
        private static object syncRoot = new object();

        private Engine()
        {
        }

        public void Run(ICommandHandler commandHandler, ILogger logger, IReader reader)
        {
            ShowHelp(logger);

            while (true)
            {
                var command = reader.ReadLine();

                if (command == QuitCommand)
                {
                    break;
                }

                try
                {
                    var output = commandHandler.Handle(command);
                    logger.WriteLine(output);
                }
                catch (Exception ex)
                {
                    logger.WriteLine(ex.Message);
                }
            }
        }

        internal static Engine GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Engine();
                    }
                }
            }

            return instance;
        }

        public static void ShowHelp(ILogger logger)
        {
            logger.WriteLine(@"Enter ""ExtractArtists(URL)"" to extract artists and print their number of albums.");
            logger.WriteLine(@"Enter ""ExtractTag(URL,TagName)"" to extract all tags and print their value.");
            logger.WriteLine(@"Enter ""ExtractFolderInfo(URL,DestinationUrl)"" to exctract all files and subdirectories into xml file.");
            logger.WriteLine(@"Enter ""ParseToXml(URL)"" to parse a text file into xml file.");
            logger.WriteLine(@"Enter ""ParseXmlToHtml(XmlURL,XslURL)"" to parse a xml file into html file.");
            logger.WriteLine(@"Enter ""DeleteAlbums(URL,MaxPrice)"" to extract artists and print their number of albums.");
            logger.WriteLine(@"Enter ""Quit"" to close the application.");
        }
    }
}
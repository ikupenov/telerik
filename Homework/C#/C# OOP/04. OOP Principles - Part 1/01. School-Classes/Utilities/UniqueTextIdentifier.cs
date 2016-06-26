namespace SchoolClasses.Utilities
{
    using System;
    using System.Collections.Generic;

    public static class UniqueTextIdentifier
    {
        private static List<string> usedIdentifiers;

        static UniqueTextIdentifier()
        {
            usedIdentifiers = new List<string>();
        }

        public static string GenerateUniqueTextIdentifier()
        {
            Random rnd = new Random();

            while (true) 
            {
                string rndIdentifier = string.Empty;

                for (int i = 0; i < 6; i++)
                {
                    int lowerOrUpper = rnd.Next(0, 2);

                    if (lowerOrUpper == 0)
                    {
                        rndIdentifier += (char)rnd.Next(65, 91);
                    }
                    else
                    {
                        rndIdentifier += (char)rnd.Next(97, 123);
                    }
                }

                if (usedIdentifiers.IndexOf(rndIdentifier) < 0)
                {
                    usedIdentifiers.Add(rndIdentifier);
                    return rndIdentifier;
                }
            }
        }
    }
}

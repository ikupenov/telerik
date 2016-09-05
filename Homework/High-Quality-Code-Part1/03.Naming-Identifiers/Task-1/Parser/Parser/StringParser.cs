namespace Parser
{
    using System;

    public class StringParser
    {
        public void ParseToBool(bool boolVariable)
        {
            string boolAsString = boolVariable.ToString();

            Console.WriteLine(boolAsString);
        }
    }
}
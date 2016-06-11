using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        var methodList = new List<string>();
        var loopList = new List<string>();
        var cStatementList = new List<string>();

        string scope = string.Empty;
        string prevScope = string.Empty;
        var separator = new char[] { ' ', ',', '(', ')', ';' };
        var dataTypes = new string[]
        {
            "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong",
            "float", "double", "decimal", "bool", "char", "string",
             "sbyte?", "byte?", "short?", "ushort?", "int?", "uint?", "long?", "ulong?",
            "float?", "double?", "decimal?", "bool?", "char?", "string?"
        };

        int loopsBracketCount = 0;
        int cStatementBracketCount = 0;

        for (int i = 0; i < N; i++)
        {
            var currentLine = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            bool isDataName = false;

            for (int j = 0; j < currentLine.Length; j++)
            {
                if (currentLine[j] == "static")
                {
                    prevScope = scope;
                    scope = "method";
                    continue;
                }
                else if (currentLine[j] == "for" || currentLine[j] == "while" || currentLine[j] == "foreach")
                {
                    prevScope = scope;
                    scope = "loop";
                    continue;
                }
                else if (currentLine[j] == "if" || currentLine[j] == "else")
                {
                    prevScope = scope;
                    scope = "cStatement";
                    continue;
                }

                if (isDataName == true && char.IsLower(currentLine[j][0]) && char.IsLetter(currentLine[j][0]))
                {
                    if (scope == "method")
                    {
                        methodList.Add(currentLine[j]);
                    }
                    else if (scope == "loop")
                    {
                        loopList.Add(currentLine[j]);
                    }
                    else if (scope == "cStatement")
                    {
                        cStatementList.Add(currentLine[j]);
                    }
                }

                if (Array.IndexOf(dataTypes, currentLine[j]) >= 0)
                {
                    isDataName = true;
                    continue;
                }

                if (scope == "loop")
                {
                    if (currentLine[j] == "{")
                        loopsBracketCount++;
                    else if (currentLine[j] == "}")
                        loopsBracketCount--;

                    if (loopsBracketCount == 0)
                        scope = prevScope;
                    //TODO SCOPE
                }
                if (scope == "cStatement")
                {
                    if (currentLine[j] == "{")
                        cStatementBracketCount++;
                    else if (currentLine[j] == "}")
                        cStatementBracketCount--;

                    if (cStatementBracketCount == 0)
                        scope = prevScope;
                    //TODO SCOPE
                }

                isDataName = false;
            }
        }

        PrintResult(methodList, loopList, cStatementList);
    }

    static void PrintResult (List<string> methodList, List<string> loopList, List<string> cStatementList)
    {
        if (methodList.Count > 0)
            Console.WriteLine("Methods -> {0} -> {1}", methodList.Count, string.Join(", ", methodList));
        else
            Console.WriteLine("Methods -> None");

        if (loopList.Count > 0)
            Console.WriteLine("Loops -> {0} -> {1}", loopList.Count, string.Join(", ", loopList));
        else
            Console.WriteLine("Loops -> None");

        if (cStatementList.Count > 0)
            Console.WriteLine("Conditional Statements -> {0} -> {1}", cStatementList.Count, string.Join(", ", cStatementList));
        else
            Console.WriteLine("Conditional Statements -> None");
    }
}
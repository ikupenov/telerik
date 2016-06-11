using System;

class Program
{
    static void Main()
    {
        string URL = Console.ReadLine();

        int protocolEnd = URL.IndexOf(':');
        string protocol = URL.Substring(0, protocolEnd);

        int serverStart = URL.IndexOf('/') + 2;
        int serverEnd = URL.IndexOf('/', serverStart + 1);
        int length = serverEnd - serverStart;
        string server = URL.Substring(serverStart, length);

        string resource = URL.Substring(serverEnd);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }
}
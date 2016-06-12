namespace NumberMatrix
{
    using System;

    [Version(4, 3)]
    public class SampleClass
    {
        public static void PrintVersion()
        {
            var type = typeof(SampleClass);
            var attributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in attributes)
            {
                Console.WriteLine("Version: {0}", attribute.Version);
            }
        }
    }
}

namespace CohesionAndCoupling
{
    using System;

    using Utils;

    public class PathExtensionsExample
    {
        public static void Start()
        {
            const string FileWithoutExtension = "example";
            const string FileWithExtension = "example.pdf";
            const string FileWithSeveralExtensions = "example.new.pdf";

            Console.WriteLine(PathExtensions.GetFileExtension(FileWithoutExtension));
            Console.WriteLine(PathExtensions.GetFileExtension(FileWithExtension));
            Console.WriteLine(PathExtensions.GetFileExtension(FileWithSeveralExtensions));

            Console.WriteLine(PathExtensions.GetFileNameWithoutExtension(FileWithoutExtension));
            Console.WriteLine(PathExtensions.GetFileNameWithoutExtension(FileWithExtension));
            Console.WriteLine(PathExtensions.GetFileNameWithoutExtension(FileWithSeveralExtensions));
        }
    }
}
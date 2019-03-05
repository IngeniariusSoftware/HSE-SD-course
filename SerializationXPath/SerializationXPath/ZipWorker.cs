
namespace SerializationXPath
{
    using System;
    using System.IO;

    using Ionic.Zip;

    public static class ZipWorker
    {
        public static string ExtractZipFiles(string path)
        {
            string outputPath;
            do
            {
                outputPath = Guid.NewGuid().ToString();
            }
            while (Directory.Exists(outputPath));

            Directory.CreateDirectory(outputPath);

            path = path ?? Directory.GetCurrentDirectory();

            foreach (string zipFile in Directory.GetFiles(path, "*zip"))
            {
                using (var zip = ZipFile.Read(zipFile))
                {
                    zip.ExtractAll(outputPath);
                }
            }

            Console.WriteLine($"\n\tФайлы распакованы в папку {outputPath}");
            return outputPath;
        }
    }
}
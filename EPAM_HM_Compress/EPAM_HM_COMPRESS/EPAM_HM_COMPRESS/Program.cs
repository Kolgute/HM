using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_COMPRESS
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "E://HM/EPAM_HM_Compress/goncharov_ivan-obyknovennaja_istorija.txt"; // исходный файл
            string compressedFile = "E://HM/EPAM_HM_Compress/goncharov_ivan-obyknovennaja_istorija.gz"; // сжатый файл
            string targetFile = "E://HM/EPAM_HM_Compress/goncharov_new.txt"; // восстановленный файл

            Compress(sourceFile, compressedFile);

            Decompress(compressedFile, targetFile);

            Console.ReadLine();
        }

        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine($"Сжатие файла {sourceFile} завершено. \nИсходный размер: {sourceStream.Length.ToString()}  \nсжатый размер: {targetStream.Length.ToString()}.");
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine($"Восстановлен файл: {targetFile}");
                    }
                }
            }
        }
    }
}

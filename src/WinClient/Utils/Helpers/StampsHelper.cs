using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace WinClient.Utils.Helpers
{
    public static class StampsHelper
    {
        private const int BYTE_ARR_MAX_LENGTH = 2147483591;

        public static void TranslateStampToXml(string stampPath, string outputXmlPath)
        {
            var binFile = TranslateStampToBin(stampPath);
            var xmlFile = TranslateBinToXml(binFile);
            File.Copy(xmlFile, outputXmlPath, true);
        }

        private static string TranslateStampToBin(string stampPath)
        {
            var fi = new FileInfo(stampPath);
            string retValPath = Path.Combine(
                Path.GetTempPath(),
                ClientHelper.CLIENT_PHYSICAL_NAME,
                "stamps");
            string retVal = Path.Combine(
                retValPath,
                fi.Name + ".bin");

            Directory.CreateDirectory(retValPath);

            byte[] binary, decompressed = new byte[BYTE_ARR_MAX_LENGTH];
            using (BinaryReader file = new BinaryReader(new FileStream(stampPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
                binary = file.ReadBytes(BYTE_ARR_MAX_LENGTH); //read the entire file
            //var output = new byte[BYTE_ARR_MAX_LENGTH];
            int outputSize;
            using (MemoryStream memory_stream = new(binary, false))
            {
                memory_stream.Read(decompressed, 0, 2); //discard 2 bytes
                using (DeflateStream compressed_file = new DeflateStream(memory_stream, CompressionMode.Decompress))
                    outputSize = compressed_file.Read(decompressed, 0, BYTE_ARR_MAX_LENGTH);
            }
            binary = new byte[outputSize];
            Array.Copy(decompressed, 0, binary, 0, outputSize);
            using (BinaryWriter outputFile = new BinaryWriter(new FileStream(retVal, FileMode.Create, FileAccess.Write)))
                outputFile.Write(binary);

            return retVal;
        }

        private static string TranslateBinToXml(string binPath)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = ClientHelper.EXE_FILE_DB_READER,
                    Arguments = @"decompress ";
                }
            };
        }
    }
}

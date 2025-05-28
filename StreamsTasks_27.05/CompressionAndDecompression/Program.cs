using System.IO.Compression;

namespace CompressionAndDecompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readStream = new FileStream("../../../textFile.txt", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../compressedTextFile.gz", FileMode.Create))
                {
                    using (GZipStream archiveStream = new GZipStream(writeStream, CompressionMode.Compress))
                    {
                        readStream.CopyTo(archiveStream);
                    }
                }
            }
            using (FileStream decompressedStream = new FileStream("../../../decompressedTextFile.txt", FileMode.Create))
            {
                using (FileStream compressedStream = new FileStream("../../../compressedTextFile.gz", FileMode.Open))
                {
                    using (GZipStream decompressor = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        decompressor.CopyTo(decompressedStream);
                    }
                }
            }
        }
    }
}

namespace ReadingFileWithStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../Program.cs"))
            {
                using(StreamWriter writer = new StreamWriter("../../../Program.txt"))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
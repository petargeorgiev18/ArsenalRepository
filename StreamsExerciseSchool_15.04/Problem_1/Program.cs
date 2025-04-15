namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                int lineNumber = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"{line}");
                    }
                    lineNumber++;
                }
            }
        }
    }
}

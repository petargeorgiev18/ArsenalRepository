namespace SavingReversedProgramCsClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Program.cs"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Program.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        char[] lineReversed = line.Reverse().ToArray();
                        for (int i = 0; i < lineReversed.Length; i++)
                        {
                            writer.Write($"{lineReversed[i]}");
                        }
                        writer.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

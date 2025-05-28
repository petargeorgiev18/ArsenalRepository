namespace WordFrequency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            string filePath = $"../../../{fileName}.txt";
            if (File.Exists(filePath))
            {
                Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineWords = line.Split(new char[] { ' ', ',', '.', '!', '?' }
                                ,StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in lineWords)
                        {
                            string wordLower = word.ToLower();
                            if (!wordFrequency.ContainsKey(wordLower))
                            {
                                wordFrequency[wordLower] = 0;
                            }
                            wordFrequency[wordLower]++;
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter($"../../../Result.txt", append: false))
                {
                    foreach (var pair in wordFrequency)
                    {
                        writer.WriteLine($"{pair.Key} -> {pair.Value} puti");
                    }
                }
            }
        }
    }
}

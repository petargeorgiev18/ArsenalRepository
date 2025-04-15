using System.Text.RegularExpressions;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToCount = File.ReadAllLines("../../../words.txt")
                                    .Select(w => w.ToLower())
                                    .Distinct()
                                    .ToArray();
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in wordsToCount)
            {
                wordCounts[word] = 0;
            }
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = Regex.Replace(line.ToLower(), @"[^\w\s]", " ");
                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                    }
                }
            }
            var sortedWordCounts = wordCounts.OrderByDescending(kvp => kvp.Value);
            using (StreamWriter writer = new StreamWriter("../../../results.txt"))
            {
                foreach (var kvp in sortedWordCounts)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            //int maxLength = 1;
            int index = 0;
            int lastIndex = 0;
            int number = 0;
            int currentMaxLength = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    currentMaxLength++;
                    index = i;
                    lastIndex = i + 1;
                    number = list[i];
                }
                currentMaxLength = 1;
            }
            for (int i = index; i <= lastIndex; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
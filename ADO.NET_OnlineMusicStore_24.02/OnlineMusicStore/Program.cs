using System.ComponentModel.Design;

namespace OnlineMusicStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(byte.MaxValue);
            Random r = new Random();
            //MusicStore.GetMenu();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                long[,] matrix = new long[46329, 46329];
                for (long i = 0; i < 46329; i++)
                {
                    for (long j = 0; j < 46329; j++)
                    {
                        matrix[i, j] = r.Next(0, 2);
                    }
                }
                for (long i = 0; i < 46329; i++)
                {
                    for (long j = 0; j < 46329; j++)
                    {
                        Console.Write("spaciq ");
                        Thread.Sleep(5);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

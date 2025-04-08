namespace DecimalToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter decimal number:");
            int decimalNum=int.Parse(Console.ReadLine());
            int reminder;
            string result = string.Empty;
            while (decimalNum > 0)
            {
                reminder = decimalNum%2;
                decimalNum /= 2;
                result = reminder.ToString()+result;
            }
            Console.WriteLine($"Decimal number that is for this binary number is {result}");
        }
    }
}

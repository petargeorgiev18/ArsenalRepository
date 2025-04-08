namespace BinaryToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter binary number:");
            string binaryNumber=Console.ReadLine();
            int decimalNumber=0;
            int power = 0;
            for (int i = binaryNumber.Length-1; i>=0; i--)
            {
                int digit = int.Parse(binaryNumber[i].ToString());
                decimalNumber += digit * (int)(Math.Pow(2, power));
                power++;
            }
            Console.WriteLine($"The decimal number for this binary number is {decimalNumber}"); 
        }
    }
}    
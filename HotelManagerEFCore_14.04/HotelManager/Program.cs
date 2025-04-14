using HotelManager.Controllers;
using HotelManager.Data;
using System.Text;

namespace HotelManager
{
    public class Program
    {
        private static HotelManagerContext context = new HotelManagerContext();
        private static HotelController controller = new HotelController(context);
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("1. Показване на всички гости");
            Console.WriteLine("2. Добавяне на нов гост");
            Console.WriteLine("3. Стаи с цена между 80 и 100 лв (в низходящ ред)");
            Console.WriteLine("4. Изтриване на резервация по ID");
            Console.WriteLine("5. Брой свободни стаи");
            Console.WriteLine("6. Минимална цена по статус");
            Console.WriteLine("7. ID-та на активни резервации");
            Console.WriteLine("0. Изход");
            Console.WriteLine();
            while (true)
            {               
                Console.Write("Моля, въведете избора си: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                switch (option)
                {
                    case 1:
                        controller.GetNamesOfAllGuests();
                        break;
                    case 2:
                        Console.Write("Име: ");
                        string firstName = Console.ReadLine()!;
                        Console.Write("Фамилия: ");
                        string lastName = Console.ReadLine()!;
                        Console.Write("ЕГН: ");
                        string EGN = Console.ReadLine()!;
                        Console.Write("Телефон: ");
                        string phoneNumber = Console.ReadLine()!;
                        controller.AddNewGuest(firstName, lastName, phoneNumber, EGN);
                        break;
                    case 3:
                        controller.GetRoomsBetween80And100();
                        break;
                    case 4:
                        Console.Write("Въведете ID на резервацията:");
                        int reservationId = int.Parse(Console.ReadLine()!);
                        controller.DeleteReservationById(reservationId);
                        break;
                    case 5:
                        controller.GetAllFreeRooms();
                        break;
                    case 6:
                        Console.Write("Въведете статус на стаята: ");
                        string status = Console.ReadLine()!;
                        controller.GetMinimalPriceByStatus(status);
                        break;
                    case 7:
                        controller.GetAllActiveReservations();
                        break;
                    default:
                        Console.WriteLine("Невалиднa опция. Моля, опитайте отново.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}

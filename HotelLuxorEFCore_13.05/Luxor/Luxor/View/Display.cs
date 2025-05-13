using Luxor.Core.Controllers.AdminControllers;
using Luxor.Core.Services.AdminServices;
using Luxor.Core.Services.GuestServices;
using Luxor.Data;
using Luxor.Data.Models;
namespace Luxor.View
{
    public class Display
    {
        private readonly LuxorDbContext context;
        private readonly AdminEmployeeService employeesService;
        private readonly AdminRoomTypeService roomTypesService;
        private readonly AdminServiceHotelService servicesHotelService;
        private readonly AdminFeedbackService feedbacksService;
        private readonly AdminBookingService bookingsService;
        private readonly AdminRoomService roomsService;
        private readonly AdminGuestService hotelGuestsService;
        private readonly GuestBookingService guestBookingsService;
        private readonly GuestFeedbackService guestFeedbacksService;
        private readonly GuestRoomService guestRoomService;
        private readonly AdminService adminService;
        public Display(LuxorDbContext context)
        {
            this.context = context;
            employeesService = new AdminEmployeeService(context);
            roomTypesService = new AdminRoomTypeService(context);
            servicesHotelService = new AdminServiceHotelService(context);
            feedbacksService = new AdminFeedbackService(context);
            bookingsService = new AdminBookingService(context);
            roomsService = new AdminRoomService(context);
            hotelGuestsService = new AdminGuestService(context);
            guestBookingsService = new GuestBookingService(context);
            guestFeedbacksService = new GuestFeedbackService(context);
            guestRoomService = new GuestRoomService(context);
            adminService = new AdminService(context);
        }
        public async Task ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to Hotel Luxor === ");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit app");
                Console.Write("Enter option: ");
                string option = Console.ReadLine()!;
                if (option == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("\n=== Login ===");
                    Console.Write("What is your name: ");
                    string name = Console.ReadLine()!;
                    Console.Write("What is your last name: ");
                    string lastName = Console.ReadLine()!;
                    Console.Write("What is your email: ");
                    string email = Console.ReadLine()!;
                    Console.Write("What is your phone number: ");
                    string phoneNumber = Console.ReadLine()!;
                    Console.Write("What is your password: ");
                    string password = Console.ReadLine()!;
                    if (name == null || lastName == null || email == null || phoneNumber == null)
                    {
                        Console.WriteLine("Please enter all the required information.");
                        return;
                    }
                    if (await adminService.CheckIfAdmin(name, lastName, email, phoneNumber, password) == true)
                    {
                        try
                        {
                            await ShowAdminMenu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (await hotelGuestsService.CheckIfGuestExists(name, lastName, email, phoneNumber, password) != null)
                    {
                        try
                        {
                            int guestId = await GetGuestId(name, lastName, email, phoneNumber, password);
                            await ShowGuestMenu(guestId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Guest not registered. If you wanna continue you need to registrate.");
                        Console.WriteLine("Do you want to make registration? y/n: ");
                        string answer = Console.ReadLine()!;
                        if(answer.ToLower()== "y")
                        {
                            Console.Clear();
                            Console.WriteLine("=== Registration ===");
                            Console.Write("What is your name: ");
                            string guestName = Console.ReadLine()!;
                            Console.Write("What is your last name: ");
                            string guestLastName = Console.ReadLine()!;
                            Console.Write("What is your email: ");
                            string guestEmail = Console.ReadLine()!;
                            Console.Write("What is your phone number: ");
                            string guestPhoneNumber = Console.ReadLine()!;
                            Console.Write("What is your password: ");
                            string guestPassword = Console.ReadLine()!;
                            await hotelGuestsService.RegistrateGuest(guestName, guestLastName, guestEmail, guestPhoneNumber, guestPassword);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (option == "2")
                {
                    Console.WriteLine("Exiting the app...");
                    return;
                }
                else
                {
                    Console.WriteLine("Invallid option. Try again");
                    Thread.Sleep(3000);
                    continue;
                }
            }
        }
        public async Task ShowAdminMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("=== Welcome to Hotel Luxor === (admin view)");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show all guests");
                Console.WriteLine("2. Show guests by last name");
                Console.WriteLine("3. Show guest by given full name");
                Console.WriteLine("4. Show guests which first name starts with given letter");
                Console.WriteLine("5. Show guests which last name starts with given letter");
                Console.WriteLine("6. Show all employees");
                Console.WriteLine("7. Show employee by ID");
                Console.WriteLine("8. Show employees by name");
                Console.WriteLine("9. Add employee/s");
                Console.WriteLine("10. Remove employee/s");
                Console.WriteLine("11. Show all bookings");
                Console.WriteLine("12. Show all bookings for room");
                Console.WriteLine("13. Show all bookings for guest");
                Console.WriteLine("14. Show bookings by status");
                Console.WriteLine("15. Show all feedbacks");
                Console.WriteLine("16. Show all feedbacks for booking ordered by rating descending");
                Console.WriteLine("17. Show feedbacks by rating for booking");
                Console.WriteLine("18. Show all room types");
                Console.WriteLine("19. Show all services");
                Console.WriteLine("20. Show all services for booking");
                Console.WriteLine("21. Add service/s to booking");
                Console.WriteLine("22. Remove service/s from booking");
                Console.WriteLine("23. Show all rooms and their type");
                Console.WriteLine("24. Add room/s");
                Console.WriteLine("25. Remove room/s");
                Console.WriteLine("26. Logout");
                Console.Write("Enter option: ");
                int option = int.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        Console.WriteLine(await hotelGuestsService.ShowAllGuests());
                        break;
                    case 2:
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine()!;
                        Console.WriteLine(await hotelGuestsService.ShowGuestsByLastName(lastName));
                        break;
                    case 3:
                        Console.Write("Enter full name of the guest: ");
                        string[] fullname = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(await hotelGuestsService.ShowGuestByGivenFullName(fullname[0], fullname[1]));
                        break;
                    case 4:
                        Console.Write("Enter letter: ");
                        char letterFirstName = char.Parse(Console.ReadLine());
                        Console.WriteLine(await hotelGuestsService.ShowGuestsWhichFirstNameStartsWithGivenLetter(letterFirstName));
                        break;
                    case 5:
                        Console.Write("Enter letter: ");
                        char letterLastName = char.Parse(Console.ReadLine()!);
                        Console.WriteLine(await hotelGuestsService.ShowGuestsWhichLastNameStartsWithGivenLetter(letterLastName));
                        break;
                    case 6:
                        Console.WriteLine(await employeesService.ShowAllEmployees());
                        break;
                    case 7:
                        Console.Write("Enter employee ID: ");
                        int employeeId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await employeesService.ShowEmployeeById(employeeId));
                        break;
                    case 8:
                        Console.Write("Enter employee name: ");
                        string name = Console.ReadLine()!;
                        Console.WriteLine(await employeesService.ShowEmployeesByName(name));
                        break;
                    case 9:
                        Console.Write("Enter employee name: ");
                        string employeeName = Console.ReadLine()!;
                        Console.Write("Enter employee age: ");
                        int age = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter employee position: ");
                        string position = Console.ReadLine()!;
                        Console.Write("Enter employee salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine()!);
                        employeesService.AddEmployee(employeeName, age, position, salary);
                        break;
                    case 10:
                        Console.Write("Enter employee name: ");
                        string employeeNameToRemove = Console.ReadLine()!;
                        Console.Write("Enter employee ID: ");
                        int employeeIdToRemove = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await employeesService.RemoveEmployee(employeeNameToRemove, employeeIdToRemove));
                        break;
                    case 11:
                        Console.WriteLine(await bookingsService.ShowAllBookings());
                        break;
                    case 12:
                        Console.Write("Enter room number: ");
                        string roomNumber = Console.ReadLine()!;
                        Console.WriteLine(await bookingsService.ShowBookingsByRoomNumber(roomNumber));
                        break;
                    case 13:
                        Console.Write("Enter guest ID: ");
                        int guestId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await bookingsService.ShowBookingsByGuestId(guestId));
                        break;
                    case 14:
                        Console.Write("Enter booking status: ");
                        string status = Console.ReadLine()!;
                        Console.WriteLine(await bookingsService.ShowBookingsByStatus(status));
                        break;
                    case 15:
                        Console.WriteLine(await feedbacksService.ShowAllFeedbacks());
                        break;
                    case 16:
                        Console.Write("Enter booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await feedbacksService.ShowAllFeedbacksByBookingIdOrderedByRatingDesc(bookingId));
                        break;
                    case 17:
                        Console.Write("Enter booking ID: ");
                        int bookingIdForFeedback = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter rating: ");
                        int rating = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await feedbacksService.ShowFeedbacksByRatingForBooking(rating, bookingIdForFeedback));
                        break;
                    case 18:
                        Console.WriteLine(await roomTypesService.ShowAllRoomTypes());
                        break;
                    case 19:
                        Console.WriteLine(await servicesHotelService.ShowAllServices());
                        break;
                    case 20:
                        Console.Write("Enter booking ID: ");
                        int bookingIdForServices = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await servicesHotelService.ShowServicesByBooking(bookingIdForServices));
                        break;
                    case 21:
                        Console.Write("Enter booking ID: ");
                        int bookingIdForAddService = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter service name: ");
                        string serviceName = Console.ReadLine()!;
                        Console.WriteLine(await servicesHotelService.AddServiceToBooking(bookingIdForAddService, serviceName));
                        break;
                    case 22:
                        Console.Write("Enter booking ID: ");
                        int bookingIdForRemoveService = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter service ID: ");
                        string serviceNameToRemove = Console.ReadLine()!;
                        Console.WriteLine(await servicesHotelService.RemoveServiceFromBooking(bookingIdForRemoveService, serviceNameToRemove));
                        break;
                    case 23:
                        Console.WriteLine(await roomsService.ShowAllRoomsAndTheirType());
                        break;
                    case 24:
                        Console.Write("Enter room number: ");
                        string roomNumberToAdd = Console.ReadLine()!;
                        Console.Write("Enter room description: ");
                        string description = Console.ReadLine()!;
                        Console.Write("Enter room price: ");
                        decimal price = decimal.Parse(Console.ReadLine()!);
                        Console.Write("Enter room type ID: ");
                        int roomTypeId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await roomsService.AddRoom(roomNumberToAdd, description, price, roomTypeId));
                        break;
                    case 25:
                        Console.Write("Enter room ID: ");
                        int roomIdToRemove = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await roomsService.RemoveRoom(roomIdToRemove));
                        break;
                    case 26:
                        Console.WriteLine("Logout...");
                        return;
                }
            }
        }
        public async Task ShowGuestMenu(int guestId)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("=== Welcome to Hotel Luxor ===");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show all free rooms");
                Console.WriteLine("2. Show all room types");
                Console.WriteLine("3. Show all services for my bookings");
                Console.WriteLine("4. Show all of my bookings");
                Console.WriteLine("5. Show all feedbacks for bookings");
                Console.WriteLine("6. Leave feedback");
                Console.WriteLine("7. Remove feedback");
                Console.WriteLine("8. Make booking");
                Console.WriteLine("9. Cancel booking");
                Console.WriteLine("10. Show all my feedbacks");
                Console.WriteLine("11. Logout");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine(await guestRoomService.ShowAvailableRooms());
                        break;
                    case 2:
                        Console.WriteLine(await roomTypesService.ShowAllRoomTypes());
                        break;
                    case 3:
                        Console.WriteLine(await roomTypesService.ShowAllRoomTypes());
                        break;
                    case 4:
                        //Console.WriteLine(await guestBookingsService.SeeAllBookingsByUser(userId));
                        break;
                    case 5:
                        //Console.WriteLine(await guestFeedbacksService.ShowAllFeedbacks());
                        break;
                    case 11:
                        Console.WriteLine("Logout...");
                        return;
                }
            }
        }
        public async Task<int> GetGuestId(string guestFirstName, string guestLastName, string email, string phoneNumber, string password)
        {
            using LuxorDbContext context = new LuxorDbContext();
            var hotelGuestsService = new AdminGuestService(context);
            Guest guest = await hotelGuestsService.CheckIfGuestExists(guestFirstName, guestLastName, email, phoneNumber, password);
            return guest.GuestId;
        }
    }
}
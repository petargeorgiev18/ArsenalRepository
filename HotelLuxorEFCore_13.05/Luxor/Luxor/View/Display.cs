using Luxor.Core.Controllers.AdminControllers;
using Luxor.Core.Services.AdminServices;
using Luxor.Core.Services.GuestService;
using Luxor.Core.Services.GuestServices;
using Luxor.Data;
using Luxor.Data.Models;
using Luxor.Data.Models.Enums;
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
        private readonly GuestService guestService;
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
            guestService = new GuestService(context);
        }
        public async Task ShowMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== Welcome to Hotel Luxor === ");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Registration");
                    Console.WriteLine("3. Exit app");
                    Console.Write("Enter option: ");
                    string option = Console.ReadLine()!;
                    if (option == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("=== Login ===");
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
                        if (name == string.Empty || lastName == string.Empty || email == string.Empty || phoneNumber == string.Empty)
                        {
                            throw new Exception("Invalid input. Try again");
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
                                Thread.Sleep(5000);
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
                                Thread.Sleep(5000);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Guest not registered. If you wanna continue you need make registration.");
                            Console.WriteLine("You're gonna be redirected on the main page after 4 seconds.");
                            Thread.Sleep(4000);
                        }
                    }
                    else if (option == "2")
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
                        if (guestName == string.Empty || guestLastName == string.Empty || guestEmail == string.Empty || guestPhoneNumber == string.Empty ||
                            guestPhoneNumber == string.Empty)
                        {
                            Console.WriteLine("Invalid input. Try again after 3 seconds. " +
                                "You're gonna be redirected to the main page.");
                            Thread.Sleep(3000);
                            continue;
                        }
                        Console.WriteLine(await hotelGuestsService.RegisterGuest(guestName, guestLastName, guestEmail, guestPhoneNumber, guestPassword));
                        Console.WriteLine("You're gonna be redirected to the main page after 4 seconds");
                        Thread.Sleep(4000);
                        continue;
                    }
                    else if (option == "3")
                    {
                        Console.WriteLine("Exiting the app...");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again after 3 seconds");
                        Thread.Sleep(3000);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Thread.Sleep(4000);
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
                Console.WriteLine("40. Change status of booking");
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
                        Console.Write("Enter employee's first name: ");
                        string employeeFirstName = Console.ReadLine()!;
                        Console.Write("Enter employee's last name: ");
                        string employeeLastName = Console.ReadLine()!;
                        Console.Write("Enter employee age: ");
                        int age = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter employee position: ");
                        string position = Console.ReadLine()!;
                        Console.Write("Enter employee salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine(await employeesService.AddEmployee(employeeFirstName, employeeLastName, age, position, salary));
                        break;
                    case 10:
                        Console.Write("Enter employee name: ");
                        string employeeNameToRemove = Console.ReadLine()!;
                        Console.WriteLine(await employeesService.RemoveEmployee(employeeNameToRemove));
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
                        Console.Write("Enter service name: ");
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
                    case 40:
                        Console.Write("Enter booking ID: ");
                        int bookingIdToChangeStatus = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter new status: ");
                        string newStatus = Console.ReadLine()!;
                        Console.WriteLine(await bookingsService.ChangeStatusOfBooking(bookingIdToChangeStatus, newStatus));
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        continue;
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
                Console.WriteLine("11. See information about me");
                Console.WriteLine("12. Update my information");
                Console.WriteLine("13. Logout");
                Console.Write("Choose option: ");
                int option = int.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        Console.WriteLine(await guestRoomService.ShowAvailableRooms());
                        break;
                    case 2:
                        Console.WriteLine(await roomTypesService.ShowAllRoomTypes());
                        break;
                    case 3:
                        Console.WriteLine(await guestBookingsService.ShowAllServicesForAnyBookingOfGuest(guestId));
                        break;
                    case 4:
                        Console.WriteLine(await guestBookingsService.SeeAllBookingsByGuest(guestId));
                        break;
                    case 5:
                        Console.WriteLine(await guestFeedbacksService.ShowAllFeedbacksForBookingsForGuest(guestId));
                        break;
                    case 6:
                        Console.Write("Enter booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter comment: ");
                        string comment = Console.ReadLine()!;
                        Console.Write("Enter rating: ");
                        int rating = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await guestFeedbacksService.LeaveFeedback(bookingId, guestId, comment, rating));
                        break;
                    case 7:
                        Console.Write("Enter feedback ID: ");
                        int feedbackId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine(await guestFeedbacksService.DeleteFeedbackForBookingByGuestId(feedbackId, guestId));
                        break;
                    case 8:
                        Console.WriteLine(await guestRoomService.ShowAvailableRooms());
                        Console.Write("Enter room number: ");
                        string roomNumber = Console.ReadLine()!;
                        int roomId = await guestRoomService.GetRoomIdByRoomNumber(roomNumber);
                        Console.Write("Enter accommodation date (yyyy-mm-dd): ");
                        DateTime accommodationDate = DateTime.Parse(Console.ReadLine()!);
                        Console.Write("Enter leaving date (yyyy-mm-dd): ");
                        DateTime leavingDate = DateTime.Parse(Console.ReadLine()!);
                        Console.Write("Enter payment method: ");
                        string paymentMethod = Console.ReadLine()!;
                        await guestBookingsService.AddBooking(guestId, roomNumber, accommodationDate, leavingDate, paymentMethod);
                        break;
                    case 9:
                        Console.Write("Enter booking ID: ");
                        int bookingIdToCancel = int.Parse(Console.ReadLine()!);
                        await guestBookingsService.DeleteBooking(guestId,bookingIdToCancel);
                        break;
                    case 10:
                        Console.WriteLine(await guestFeedbacksService.ShowAllFeedbacksForBookingsForGuest(guestId));
                        break;
                    case 11:
                        Console.WriteLine(await guestService.SeeInformationAboutGuest(guestId));
                        break;
                    case 12:
                        Console.Write("Enter new first name: ");
                        string firstName = Console.ReadLine()!;
                        Console.Write("Enter new last name: ");
                        string lastName = Console.ReadLine()!;
                        Console.Write("Enter new email: ");
                        string email = Console.ReadLine()!;
                        Console.Write("Enter new phone number: ");
                        string phoneNumber = Console.ReadLine()!;
                        Console.Write("Enter new password: ");
                        string password = Console.ReadLine()!;
                        Console.WriteLine(await guestService.UpdateInfoForGuest(guestId,firstName,lastName,email,phoneNumber,password));
                        break;
                    case 13:
                        Console.WriteLine("Logout...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        continue;
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
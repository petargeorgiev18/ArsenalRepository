using System;
using System.Threading.Tasks;
using FormulaOneMVC.Controllers;

namespace FormulaOneMVC.Presentation
{
    public class Display
    {
        private readonly TeamController teamController;
        private readonly DriverController driverController;
        public Display()
        {
            teamController = new TeamController();
            driverController = new DriverController();
        }
        public async Task ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Formula 1 MVC Console App ===");
                Console.WriteLine("1. Get all teams.");
                Console.WriteLine("2. Get team by ID.");
                Console.WriteLine("3. Get teams by country.");
                Console.WriteLine("4. Get oldest team.");
                Console.WriteLine("5. Get all drivers.");
                Console.WriteLine("6. Get driver by ID.");
                Console.WriteLine("7. Get driver by last name.");
                Console.WriteLine("8. Get drivers by nationality.");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            Console.WriteLine(await teamController.GetAllTeams());
                            break;

                        case 2:
                            Console.Write("Enter team ID: ");
                            int teamId = int.Parse(Console.ReadLine());
                            Console.WriteLine(await teamController.GetTeamById(teamId));
                            break;

                        case 3:
                            Console.Write("Enter country: ");
                            string country = Console.ReadLine();
                            Console.WriteLine(await teamController.GetTeamsByCountry(country));
                            break;

                        case 4:
                            Console.WriteLine(await teamController.GetOldestTeam());
                            break;

                        case 5:
                            Console.WriteLine(await driverController.GetAllDrivers());
                            break;

                        case 6:
                            Console.Write("Enter driver ID: ");
                            int driverId = int.Parse(Console.ReadLine());
                            Console.WriteLine(await driverController.GetDriverById(driverId));
                            break;

                        case 7:
                            Console.Write("Enter driver's last name: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine(await driverController.GetDriverByName(lastName));
                            break;

                        case 8:
                            Console.Write("Enter nationality: ");
                            string nationality = Console.ReadLine();
                            Console.WriteLine(await driverController
                                .GetDriversByNationality(nationality));
                            break;

                        case 9:
                            return;

                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
        }
    }
}
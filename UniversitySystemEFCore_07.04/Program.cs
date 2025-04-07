using UniversitySystemEFCore.Controllers;
using UniversitySystemEFCore.Data;
using UniversitySystemEFCore.Presentation;

namespace UniversitySystemEFCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using UniversityDbContext context = new UniversityDbContext();
            FacultyController facultyController = new FacultyController(context);
            MajorController majorController = new MajorController(context);
            UniversityController universityController = new UniversityController(context);
            Display display = new Display(universityController, facultyController, majorController);
            await display.ShowMenu();
        }
    }
}

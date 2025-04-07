using UniversitySystemEFCore.Controllers;

namespace UniversitySystemEFCore.Presentation
{
    public class Display
    {
        private UniversityController universityController;
        private FacultyController facultyController;
        private MajorController majorController;
        public Display(UniversityController universityController, FacultyController facultyController,
            MajorController majorController)
        {
            this.universityController = universityController;
            this.facultyController = facultyController;
            this.majorController = majorController;
        }
        public async Task ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add university");
                Console.WriteLine("2. Add faculty");
                Console.WriteLine("3. Add major");
                Console.WriteLine("4. Show all universities");
                Console.WriteLine("5. Show faculties by university ID");
                Console.WriteLine("6. Show majors by faculty ID");
                Console.WriteLine("7. Show university ID by name");
                Console.WriteLine("8. Show faculty ID and name by name");
                Console.WriteLine("9. Show major ID and name by name");
                Console.WriteLine("10. Exit");
                int numberOfCommand = int.Parse(Console.ReadLine()!);               
                switch (numberOfCommand)
                {
                    case 1:
                        Console.WriteLine("Enter university name:");
                        string universityName = Console.ReadLine()!;
                        await InputUniversity(universityName);
                        break;
                    case 2:
                        Console.WriteLine("Enter faculty name:");
                        string facultyName = Console.ReadLine()!;
                        Console.WriteLine("Enter university ID:");
                        int universityId = int.Parse(Console.ReadLine()!);
                        InputFaculty(facultyName, universityId).Wait();
                        break;
                    case 3:
                        Console.WriteLine("Enter major name:");
                        string majorName = Console.ReadLine()!;
                        Console.WriteLine("Enter faculty ID:");
                        int facultyId = int.Parse(Console.ReadLine()!);
                        InputMajor(majorName, facultyId).Wait();
                        break;
                    case 4:
                        await GetAllUniversities();
                        break;
                    case 5:
                        Console.WriteLine("Enter university ID:");
                        int uniId = int.Parse(Console.ReadLine()!);
                        await GetFacultiesByUniversityId(uniId);
                        break;
                    case 6:
                        Console.WriteLine("Enter faculty ID:");
                        int facId = int.Parse(Console.ReadLine()!);
                        await GetMajorsByFacultyId(facId);
                        break;
                    case 7:
                        Console.WriteLine("Enter university name:");
                        string uniName = Console.ReadLine()!;
                        await GetUniversityIdByName(uniName);
                        break;
                    case 8:
                        Console.WriteLine("Enter faculty name:");
                        string facName = Console.ReadLine()!;
                        Console.WriteLine("Enter university ID:");
                        int uniId2 = int.Parse(Console.ReadLine()!);
                        await GetFacultyIdAndNameByName(facName, uniId2);
                        break;
                    case 9:
                        Console.WriteLine("Enter major name:");
                        string majName = Console.ReadLine()!;
                        Console.WriteLine("Enter faculty ID:");
                        int facId2 = int.Parse(Console.ReadLine()!);
                        await GetMajorIdAndNameByName(majName, facId2);
                        break;
                    case 10:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }
        public async Task InputUniversity(string name)
        {
            await universityController.AddUniversity(name);
        }
        public async Task InputFaculty(string name, int universityId)
        {
            await facultyController.AddFaculty(name, universityId);
        }
        public async Task InputMajor(string name, int facultyId)
        {
            await majorController.AddMajor(name, facultyId);
        }
        public async Task GetAllUniversities()
        {
            var universities = await universityController.GetAllUniversities();
            foreach (var university in universities)
            {
                Console.WriteLine($"ID: {university.Id}, Name: {university.Name}");
            }
        }
        public async Task GetFacultiesByUniversityId(int universityId)
        {
            var faculties = await facultyController.GetFacultiesByUniversityId(universityId);
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"ID: {faculty.Id}, Name: {faculty.Name}");
            }
        }
        public async Task GetMajorsByFacultyId(int facultyId)
        {
            var majors = await majorController.GetMajorsByFacultyId(facultyId);
            foreach (var major in majors)
            {
                Console.WriteLine($"ID: {major.Id}, Name: {major.Name}");
            }
        }
        public async Task GetUniversityIdByName(string name)
        {
            var university = await universityController.GetUniversityByName(name);
            if (university != null)
            {
                Console.WriteLine($"ID: {university.Id}, Name: {university.Name}");
            }
            else
            {
                Console.WriteLine("University not found");
            }
        }
        public async Task GetFacultyIdAndNameByName(string name, int universityId)
        {
            var faculty = await facultyController.GetFacultyByNameAndUniversityId(name, universityId);
            if (faculty != null)
            {
                Console.WriteLine($"ID: {faculty.Id}, Name: {faculty.Name}");
            }
            else
            {
                Console.WriteLine("Faculty not found");
            }
        }
        public async Task GetMajorIdAndNameByName(string name, int facultyId)
        {
            var major = await majorController.GetMajorByNameAndFacultyId(name, facultyId);
            if (major != null)
            {
                Console.WriteLine($"ID: {major.Id}, Name: {major.Name}");
            }
            else
            {
                Console.WriteLine("Major not found");
            }
        }
    }
}

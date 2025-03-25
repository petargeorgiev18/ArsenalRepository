using FormulaOneMVC.Controllers;
using FormulaOneMVC.Data;
using FormulaOneMVC.Presentation;

namespace FormulaOneMVC
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            Display showMenu = new Display();
            await showMenu.ShowMenu();
        }
    }
}

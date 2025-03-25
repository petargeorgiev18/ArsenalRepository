using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneMVC.Controllers
{
    public class DriverController
    {
        public DriverController() { }
        public async Task<string> GetAllDrivers()
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var drivers = await context.Drivers.ToListAsync();
            foreach (var driver in drivers)
            {
                sb.AppendLine(driver.FirstName + " " + driver.LastName);
            }
            return sb.ToString().Trim();
        }
        public async Task<string> GetDriverById(int id)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var driver = await context.Drivers.FindAsync(id);
            sb.AppendLine(driver!.FirstName + " " + driver.LastName);
            return sb.ToString().Trim();
        }
        public async Task<string> GetDriversByTeam(string teamName)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var drivers = await context.Drivers.Where(d => d.Team!.TeamName == teamName).ToListAsync();
            foreach (var driver in drivers)
            {
                sb.AppendLine(driver.FirstName + " " + driver.LastName);
            }
            return sb.ToString().Trim();
        }
        public async Task<string> GetDriversByNationality(string nationality)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var drivers = await context.Drivers.Where(d => d.Nationality == nationality).ToListAsync();
            foreach (var driver in drivers)
            {
                sb.AppendLine(driver.FirstName + " " + driver.LastName);
            }
            return sb.ToString().Trim();
        }
        public async Task<string> GetDriverByName(string lastName)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var drivers = await context.Drivers.Where(d => d.LastName == lastName).ToListAsync();
            foreach (var driver in drivers)
            {
                sb.AppendLine(driver.FirstName + " " + driver.LastName);
            }
            return sb.ToString().Trim();
        }
    }
}

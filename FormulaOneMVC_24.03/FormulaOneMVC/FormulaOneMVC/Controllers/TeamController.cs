using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneMVC.Controllers
{
    public class TeamController
    {
        public TeamController() { }
        public async Task<string> GetAllTeams()
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var teams = await context.Teams.ToListAsync();
            foreach (var team in teams)
            {
                sb.AppendLine(team.TeamName);
            }
            return sb.ToString().Trim();
        }
        public async Task<string> GetTeamById(int id)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var team = await context.Teams.FindAsync(id);
            sb.AppendLine(team!.TeamName);
            return sb.ToString().Trim();
        }
        public async Task<string> GetTeamsByCountry(string country)
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var teams = await context.Teams.Where(t => t.Country == country).ToListAsync();
            foreach (var team in teams)
            {
                sb.AppendLine(team.TeamName);
            }
            return sb.ToString().Trim();
        }
        public async Task<string> GetOldestTeam()
        {
            using FormulaOneDbContext context = new FormulaOneDbContext();
            StringBuilder sb = new StringBuilder();
            var team = await context.Teams.OrderBy(t => t.FoundationYear).FirstOrDefaultAsync();
            sb.AppendLine(team!.TeamName);
            return sb.ToString().Trim();
        }
    }
}

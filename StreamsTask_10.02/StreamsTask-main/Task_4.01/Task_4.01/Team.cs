using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class Team
    {
	private string name;
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
        public List<IPlayer> Players { get; set; }
        private ILog log;
        private ILog exceLog;
        public Team(string name)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Name = name;
            Players = new List<IPlayer>();
            log = new TextLog(@$"{path}\file.txt");
            exceLog = new ExcelLogger(@$"{path}\file.xlsx");
            string logMessage = $"Team {name} created at {DateTime.Now}";
            log.Log(logMessage);
            exceLog.Log(logMessage);
        }
        public void add_player(IPlayer playerToAdd)
        {
            IPlayer player = Players.FirstOrDefault(p => p.Name == playerToAdd.Name && p.Position == playerToAdd.Position);
            if (player == null)
            {
                Players.Add(playerToAdd);
                string logMessage = $"Player {playerToAdd.Name} with position {playerToAdd.Position} added to team " +
                    $"{Name} at {DateTime.Now}";
                log.Log(logMessage);
                exceLog.Log(logMessage);
                Console.WriteLine(logMessage);
            }
            else
            {
                string logMessage = $"The player {player.Name} already exists in team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                exceLog.Log(logMessage);
                Console.WriteLine(logMessage);
            }
        }
        public void remove_player(string playerName)
        {
            IPlayer player = Players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                Players.Remove(player);
                string logMessage = $"Player {player.Name} removed from team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                exceLog.Log(logMessage);
                Console.WriteLine(logMessage);
            }
            else
            {
                string logMessage = $"No player named {playerName} found in team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                exceLog.Log(logMessage);
                Console.WriteLine(logMessage);
            }
        }
        public void SaveLogToFile(string fileType)
        {
            switch (fileType)
            {
                case "txt":
                    log.SaveLog();
                    break;
                case "excel":
                    exceLog.SaveLog();
                    break;
                default:
                    Console.WriteLine($"Not existent type to log - {fileType}");
                    return;
            }
            
        }
        public void PrintLogToConsole(string fileType)
        {
            Console.WriteLine($"Log history for team {this.Name}:");
            switch (fileType)
            {
                case "txt":
                    Console.WriteLine(log.GetLog());
                    break;
                case "excel":
                    Console.WriteLine(exceLog.GetLog());
                    break;
                default:
                    Console.WriteLine($"Not existent type to log - {fileType}");
                    return;
            }
        }
    }
}

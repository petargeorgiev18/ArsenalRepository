using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class Player:IPlayer
    {
	private string name;
	public string Name
	{
	        get { return name; }
		set { name = value; }
	}
	private string position;
	public string Position
	{
		get { return position; }
		set { position = value; }
	}
        public Player(string name, string position)
        {
            Name = name;
	    Position = position;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Grid
    {
        public enum PlaceShipDirection
        {
            Horizontal, Vertical
        }

        public Point[,] Ocean {get;set;}
        public List<Ship> ListOfShips {get; set;}
        public bool AllShipsDestroyed {get; 
        {
            return this.ListOfShips.All(x => x.IsDestroyed);
        }
        }

        public Grid()
        {
            this.Ocean = new Point [10, 10];
            for (int y = 0; y < 10; y++)
			{
			 for (int x = 0; x < 10; x++)
			{
			 this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
			}
			}

        }
        public void PlaceShip(Ship shipPlace, PlaceShipDirection direction, int startOfX, int startOfY)
        {
            for (int i = 0; i < shipPlace.Length; i++)
			{
			 Ocean[startOfX, startOfY].Status = PointStatus.Ship;
                shipPlace.OccupiedPoints.Add(Ocean[startOfX, startOfY]);
                if (direction == PlaceShipDirection.Horizontal)
	{
		 startOfX++;
	}
                else
	{
                    startOfY++;
	}
			}
            this.ListOfShips.Add(shipPlace);
        }
        public void Display()
        {
                Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("  X  0 1 2 3 4 5 6 7 8 9 ");
            Console.WriteLine("-------------------------");
        
        for (int y = 0; y < 10; y++)
			{
			 Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" I ");
            for (int x = 0; x < 10; x++)
			{
			 if (Ocean[x, y].Status == PointStatus.Empty || Ocean[x, y].Status == PointStatus.Ship)
	{
		 Console.WriteLine("( )");
	}
                else if (Ocean[x, y].Status == PointStatus.Hit)
	{
		 Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("(X)");
	}
             else if (Ocean[x, y].Status == PointStatus.Miss)
	{
		 Console.ForegroundColor = ConsoleColor.White;
                 Console.WriteLine("(O)");
	}
			}
            Console.WriteLine();
			}
        }
        public void Target(int x, int y)
        {
            if (Ocean[x, y].Status == PointStatus.Ship)
	{
 		 Ocean[x, y].Status = PointStatus.Hit;
	}
            else if (Ocean[x, y].Status == PointStatus.Miss)
	{
		 
	}
        
    }
        public void PlayGame()
        {
            while (!AllShipsDestroyed)
	{
                Display();
                string exception = "", yexception = "";
                while (exception == "")
	{
	         Console.WriteLine("Enter your first coordinate:");
                 Console.ReadLine();
	}
	         int x = int.Parse(exception)
                 while (yexception = "")
	{
	         Console.WriteLine("Enter your second coordinate:");
                     Console.ReadLine();
	}
                int y = int.Parse(yexception)

                    if (x <= 9 && y <= 9)
	{
	Target(x, y);
	          
	}
	
            Display();
            Console.WriteLine("Congratulations, You Win!");
            DisplayHighScore();

             
        }
            
        }
        static void AddHighScore(int playerscore)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            ForrestEntities db = new ForrestEntities();

            HighScore newHighScore = new HighScore();
            newHighScore.Name = playername;
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Battleship";
            newHighScore.Score = playerscore;

            db.HighScores.Add(newHighScore);

            db.Save();
        }
        static void DisplayHighScore()
    {
            Console.WriteLine("High Scores");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            ForrestEntities db = new ForrestEntities();
            List<HighScore> HighScoreList = db.HighScores.Where(x => x.Game == "Battleship").OrderBy(x => x.Score).Take(10).ToList();

            foreach (HighScore highscore in HighScoreList)
	{
		    Console.WriteLine("{0}, {1} Took {2} tries to win! {3}", HighScoreList.IndexOf(highscore) + 1, highscore.Score, highscore.Date.Value.ToShortDateString());
	}
    }
}
}

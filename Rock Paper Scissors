
Game game = new Game();
Record record = new Record();

while (true)
{
    Game.Match(game, record);
    record.DisplayScore();
}


public class Game
{
    // PLayer 1 results
    public bool Win { get; internal set;  }
    public bool Draw { get; internal set;  }

    private static Rps Choice()
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "rock") return Rps.Rock;
        else if (input.ToLower() == "paper") return Rps.Paper;
        else if (input.ToLower() == "scissors") return Rps.Scissors;
        else
        {
            Console.WriteLine("Invalid Choice");
            return Rps.Rock;
        }
    }

    public static void Match(Game game, Record record)
    {
        game.Draw = false;
        game.Win = false;
        
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Player 1, please enter your choice:");
        Rps p1 = Choice();
        // Console.Clear();
        Console.WriteLine("Player 2, please enter your choice:");
        Rps p2 = Choice();
        
        if (p1 == p2) game.Draw = true;
        else if (p1 == Rps.Rock && p2 == Rps.Scissors) game.Win = true;
        else if (p1 == Rps.Paper && p2 == Rps.Rock) game.Win = true;
        else if (p1 == Rps.Scissors && p2 == Rps.Paper) game.Win = true;

        Console.ForegroundColor = ConsoleColor.Green;
        if (game.Win)
        {
            record.Win1++;
            Console.WriteLine("Player 1 Wins!");
        }
        else if (game.Draw)
        {
            record.Draw1++;
            Console.WriteLine("Draw!");
        }
        else Console.WriteLine("Player 2 Wins!");

        record.Round++;
    }
}

public class Record
{
    public int Win1 { get; set; } = 0;
    public int Draw1 { get;  set; } = 0;
    public int Round { get; set; } = 0;
    public int Draw2 => Draw1;
    public int Win2 => Round - (Draw1 + Win1);

    public void DisplayScore()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"Player 1 - Wins:{Win1}, Draw:{Draw1}");
        Console.WriteLine($"Player 2 - Wins:{Win2}, Draw:{Draw2}");
        Console.WriteLine("____________________________________");
    }
}

public enum Rps {Rock, Paper, Scissors}


FountainOfObjects game = Configure();
Console.Clear();

game.Program();


FountainOfObjects SmallGame()
{
    Player player = new Player(new Position(0, 0));
    Fountain fountain = new Fountain(new Position(0, 2));
    Entrance entrance = new Entrance(new Position(0, 0));
    Pit[] pit = new Pit[] {new Pit(new Position(0, 1))};
    Maelstrom[] maelstrom = new Maelstrom[] {new Maelstrom(new Position(2, 2))};
    Amarok[] amarok = new Amarok[] {new Amarok(new Position(1, 2))};

    return new FountainOfObjects(player, fountain, entrance, 3, pit, maelstrom, amarok);
}

FountainOfObjects MediumGame()
{
    Player player = new Player(new Position(0, 4));
    Fountain fountain = new Fountain(new Position(2, 0));
    Entrance entrance = new Entrance(new Position(0, 4));
    Pit[] pit = new Pit[] {new Pit(new Position(2, 5)), new Pit(new Position(1, 2))};
    Maelstrom[] maelstrom = new Maelstrom[] {new Maelstrom(new Position(4, 4))};
    Amarok[] amarok = new Amarok[] {new Amarok(new Position(0, 1)), new Amarok(new Position(4, 1))};
    
    return new FountainOfObjects(player, fountain, entrance, 5, pit, maelstrom, amarok);
}

FountainOfObjects LargeGame()
{
    Player player = new Player(new Position(4, 0));
    Fountain fountain = new Fountain(new Position(7, 1));
    Entrance entrance = new Entrance(new Position(4, 0));
    Pit[] pit = new []{new Pit(new Position(7, 0)), new Pit(new Position(2, 1)), new Pit(new Position(1, 6)), 
        new Pit(new Position(7, 4))};
    Maelstrom[] maelstrom = new Maelstrom[] {new Maelstrom(new Position(0, 1)), new Maelstrom(new Position(4, 4))};
    Amarok[] amarok = new Amarok[] {new Amarok(new Position(6, 1)), new Amarok(new Position(1, 3)),
        new Amarok(new Position(4, 6))};
    
    return new FountainOfObjects(player, fountain, entrance, 7, pit, maelstrom, amarok);
}

FountainOfObjects Configure()
{
    Console.WriteLine("1: Small, 2: Medium, 3: Large");
    string? input = Console.ReadLine();

    return input switch
    {
        "1" => SmallGame(),
        "2" => MediumGame(),
        "3" => LargeGame(),
        _ => Configure()
    };
}

//  GAME

public class FountainOfObjects
{
    public Player Player;
    public Fountain Fountain;
    public Entrance Entrance;
    public Pit[] Pit;
    public Maelstrom[] Maelstrom;
    public Amarok[] Amarok;
    public int MapSize { get; set; }

    public FountainOfObjects(Player player, Fountain fountain, Entrance entrance, int mapSize, Pit[] pit
        , Maelstrom[] maelstrom, Amarok[] amarok)
    {
        Player = player;
        Fountain = fountain;
        Entrance = entrance;
        Pit = pit;
        Maelstrom = maelstrom;
        Amarok = amarok;
        MapSize = mapSize;
    }
    
    public void Program()
    {
        while (Player.Alive)
        {
            
            SomeMethods.Write("_____________________________________________________________________________");
            SomeMethods.Write($"You are in the room at ({Player.Position.X}, {Player.Position.Y})");
            
            // Win-Lose cond
            if (SomeMethods.SamePosition(Player.Position, Entrance.Position) && Fountain.Enabled)
            {
                SomeMethods.Write("You Win!", ConsoleColor.Green);
                break;
            }
            
            foreach (Pit pit in Pit)
            {
                if(SomeMethods.SamePosition(Player.Position, pit.Position))
                {
                    SomeMethods.Write("You Die!", ConsoleColor.Red);
                    Player.Alive = false;
                    break;
                }
            }
            
            foreach (Amarok amarok in Amarok)
            {
                if(amarok.Alive && SomeMethods.SamePosition(Player.Position, amarok.Position))
                {
                    SomeMethods.Write("You Die!", ConsoleColor.Red);
                    Player.Alive = false;
                    break;
                }
            }

            if (!Player.Alive) break;
            
            // Info
            if (SomeMethods.SamePosition(Player.Position, Entrance.Position)) SomeMethods.Write("You see light coming " +
                "from the cavern entrance", ConsoleColor.Yellow);
            
            if(SomeMethods.SamePosition(Player.Position, Fountain.Position))
            {
                if(Fountain.Enabled)
                    SomeMethods.Write("You hear the rushing waters from the Fountain of Objects. " +
                                  "It has been reactivated!", ConsoleColor.Blue);
                else 
                    SomeMethods.Write("You hear water dripping in this room. The Fountain of Objects is here!",
                    ConsoleColor.DarkBlue);
            }
            
            foreach (Maelstrom maelstrom in Maelstrom)
            {
                if(maelstrom.Alive && SomeMethods.Adjacent(maelstrom.Position, Player.Position))
                    SomeMethods.Write("You hear the growling and groaning of a malestrom nearby.", ConsoleColor.DarkCyan);
            }
            
            foreach (Amarok amarok in Amarok)
            {
                if(amarok.Alive && SomeMethods.Adjacent(Player.Position, amarok.Position))
                    SomeMethods.Write("You can smell the rotten stench of an amarok in a nearby room.", ConsoleColor.DarkMagenta);
            }
            
            // Monster Encounter
            foreach (Maelstrom maelstrom in Maelstrom)
            {
                if (maelstrom.Alive && SomeMethods.SamePosition(Player.Position, maelstrom.Position))
                {
                    Player.Position = new Position(Math.Clamp(Player.Position.X + 2, 0, MapSize), Math.Clamp(Player.Position.Y + 1, 0, MapSize));
                    maelstrom.Position = new Position(Math.Clamp(maelstrom.Position.X - 2, 0, MapSize), Math.Clamp(maelstrom.Position.Y - 2, 0, MapSize));
                    SomeMethods.Write("You have been hit by a Maelstrom", ConsoleColor.DarkCyan);
                    SomeMethods.Write($"You are in the room at ({Player.Position.X}, {Player.Position.Y})");
                }
            }
            
            foreach (Pit pit in Pit)
            {
                if(SomeMethods.Adjacent(pit.Position, Player.Position))
                    SomeMethods.Write("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Gray);
            }

            
            
            // Command
            CommandGet().Execute(this);
        }
    }
    
    private ICommand CommandGet()
    {
        SomeMethods.Write("What do you want to do?");
        while (true)
        {
            string? input = Console.ReadLine()?.ToLower();
            return input switch
            {
                "north" => new Move(input),
                "east" => new Move(input),
                "south" => new Move(input),
                "west" => new Move(input),
                "enable" => new EnableFountain(),
                "shoot north" => new Shoot("north"),
                "shoot south" => new Shoot("south"),
                "shoot east" => new Shoot("east"),
                "shoot west" => new Shoot("west"),
                _ => CommandGet()
            };
        }
    }
}

//  OBJECTS
public record Position(int X, int Y);

public class Player
{
    public Position Position { get; set; }
    public bool Alive { get; set; } = true;

    public Player(Position position)
    {
        Position = position;
    }
}

public class Fountain
{
    public Position Position { get; set; }
    public bool Enabled { get; set; }
    public Fountain(Position position)
    {
        Position = position;
    }
}

public class Entrance
{
    public Position Position { get; set; }

    public Entrance(Position position)
    {
        Position = position;
    }
}

public class Pit
{
    public Position Position { get; set; }

    public Pit(Position position)
    {
        Position = position;
    }
}

public class Maelstrom
{
    public Position Position { get; set; }
    public bool Alive { get; set; } = true;

    public Maelstrom(Position position)
    {
        Position = position;
    }
}

public class Amarok
{
    public Position Position { get; set; }
    public bool Alive { get; set; } = true;

    public Amarok(Position position)
    {
        Position = position;
    }
}

//  INTERFACES
public class Move : ICommand
{
    public string Input { get; set; }

    public Move(string input)
    {
        Input = input;
    }
    
    public void Execute(FountainOfObjects game)
    {
        Position p = game.Player.Position;
        Position newPosition = Input switch
        {
            "north"  => new Position(p.X, p.Y + 1),
            "south"  => new Position(p.X, p.Y - 1),
            "east"  => new Position(p.X + 1, p.Y),
            "west"  => new Position(p.X - 1, p.Y),
            _ => p
        };
        if (newPosition.X <= game.MapSize && newPosition.Y <= game.MapSize && newPosition.X >= 0 && newPosition.Y >= 0)
        {
            game.Player.Position = newPosition;
        }
    }
}

public class EnableFountain : ICommand
{
    public void Execute(FountainOfObjects game)
    {
        if (SomeMethods.SamePosition(game.Player.Position, game.Fountain.Position))
            game.Fountain.Enabled = true;
    }
}

public class Shoot : ICommand
{
    private int Arrows { get; set; } = 4;
    private string _input;

    public Shoot(string input)
    {
        _input = input;
    }
    
    public void Execute(FountainOfObjects game)
    {
        if (Arrows > 0)
        {
            Kill_on_Tile(Targeting(game), game);
            Arrows --;
            Console.WriteLine(Arrows);
        }
        else SomeMethods.Write("You don't have any arrows left", ConsoleColor.DarkYellow);
    }

    private Position Targeting(FountainOfObjects game)
    {
        Position p = game.Player.Position;
        return _input switch
        {
            "north"  => new Position(p.X, p.Y + 1),
            "south"  => new Position(p.X, p.Y - 1),
            "east"  => new Position(p.X + 1, p.Y),
            "west"  => new Position(p.X - 1, p.Y),
        };
    }

    private void Kill_on_Tile(Position position, FountainOfObjects game)
    {
        foreach (Maelstrom maelstrom in game.Maelstrom)
        {
            if(SomeMethods.SamePosition(maelstrom.Position, position))
                maelstrom.Alive = false;
        }
        
        foreach (Amarok amarok in game.Amarok)
        {
            if(SomeMethods.SamePosition(amarok.Position, position))
                amarok.Alive = false;
        }
    }
}


public interface ICommand
{
    void Execute(FountainOfObjects game);
}

// Helpful methods

public static class SomeMethods
{
    public static void Write(string text, ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static bool SamePosition(Position p1, Position p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }

    public static bool Adjacent(Position p1, Position p2)
    {
        int xDiff = Math.Abs(p2.X - p1.X);
        int yDiff = Math.Abs(p2.Y - p1.Y);
        return xDiff <=1 && yDiff <=1;
    }
}


Robot myRobot = new Robot();

while (true)
{
    while (true)
    {
        string? input = Console.ReadLine()!;
        if (input == "stop" || input == null) break;
        myRobot.Commands.Add(Input(input));
    }
    
    myRobot.Run();
}


IRobotCommand Input(string input)
{
    switch (input)
    {
        case "on":
        {
            return new OnCommand();
        }
        case "off":
        {
            return new OffCommand();
        }
        case "north":
        {
            return new NorthCommand();
        }
        case "south":
        {
            return new SouthCommand();
        }
        case "west":
        {
            return new WestCommand();
        }
        case "east":
        {
            return new EastCommand();
        }
        default: return null;
    }
}



public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; set; } = new List<IRobotCommand>(1);

    public void Run()
    {
        foreach (var command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X += 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X -= 1;
    }
}

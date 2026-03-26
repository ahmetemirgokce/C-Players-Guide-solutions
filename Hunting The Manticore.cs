
int AskNumber(string question)
{
    while (true)
    {
        Console.Write(question);
        int number = Convert.ToInt32(Console.ReadLine());
        if (number < 0 || number > 100)
        {
            Console.WriteLine("Invalid input");
            AskNumber(question);
        }
        return number;
    }
}


void Separate()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("______________________________________________");
}


void Status(int round, int city, int boss)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {boss}/10");
}


int RoundType(int round)
{
    if (round % 3 != 0 && round % 5 != 0) return 0; //normal
    else if (round % 3 == 0 && round % 5 != 0) return 2; //fire
    else if (round % 3 != 0 && round % 5 == 0) return 3; //electric
    else return 1; //combined
}


int CannonDamage(int type)
{
    return type switch
    {
        1 =>  15,
        2 =>  3,
        3 =>  3,
        0 =>  1
    };
}


void Cannon(int type)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write("The cannon is expected to deal ");
    switch (type)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(CannonDamage(type));
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(CannonDamage(type));
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(CannonDamage(type));
            break;
        case 0:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(CannonDamage(type));
            break;
    }

    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(" damage this round.");
}


int range = AskNumber("Player 1, how far is Manticore?");
int city = 15;
int boss = 10;
Console.Clear();
Console.WriteLine("Player 2, it is your turn");


for (int round = 1; round < 26; round++)
{
    Separate();
    Status(round, city, boss);
    Cannon(RoundType(round));
    int hit = AskNumber("\nEnter desired cannon range: ");

    if (hit > range)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("OVERSHOT");
        --city;
    }
    else if (hit < range)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("FELL SHORT");
        --city;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("DIRECT HIT!");
        boss -= CannonDamage(RoundType(round));
    }

    if (city == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Consolas has fallen");
        Console.WriteLine("Millions must die");
        break;
    }

    if (boss <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Manticore has been destroyed, millions must live!");
        break;
    }
}

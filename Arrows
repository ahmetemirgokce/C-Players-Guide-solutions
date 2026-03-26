
int AskNumber(string question, int min, int max)
{
    while (true)
    {
        Console.Write(question);
        int number = Convert.ToInt32(Console.ReadLine());
        if (number < min || number > max)
        {
            Console.WriteLine("Invalid input");
            AskNumber(question, min, max);
        }
        return number;
    }
}


Arrowhead PickHead() 
{
    int i = 1;
    foreach (string s in Enum.GetNames(typeof(Arrowhead))) //converts enum to an array of strings
    {
        Console.WriteLine($"{i}: {s}");
        i++;
    }
    int picker = AskNumber("", 0, (Enum.GetNames(typeof(Arrowhead))).Length);
    return (Arrowhead)(picker-1);
}


Fletching PickFletc() 
{
    int i = 1;
    foreach (string s in Enum.GetNames(typeof(Fletching))) //converts enum to an array of strings
    {
        Console.WriteLine($"{i}: {s}");
        i++;
    }
    int picker = AskNumber("", 0, (Enum.GetNames(typeof(Fletching))).Length);
    return (Fletching)(picker-1);
}


Arrow CreateArrow()
{
    Console.WriteLine("Options: \n1: Elite Arrow\n2: Beginner Arrow\n3: Marksman Arrow\n4: Custom Arrow");
    int input = AskNumber("Enter an integer between 1 and 4", 1, 4);
    Arrow x = new Arrow();
    x = input switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow(),
        4 => new Arrow() { _Arrowhead = PickHead(), _Fletching = PickFletc(),
            _Shaft = AskNumber("enter length between 60 and 100 (in cm)", 60, 100) }
    };
    return x;
}


Arrow customerArrow = new Arrow();
customerArrow = CreateArrow();
float x = customerArrow.GetCost();
Console.WriteLine($"The cost is: {x}");


class Arrow
{
    public Arrowhead _Arrowhead { get; set; }
    public Fletching _Fletching { get; set; }
    public int _Shaft { get; set; }
    
    public float GetCost()
    {
        float cost = 0;

        cost = this._Arrowhead switch
        {
            Arrowhead.Steel =>  cost += 10,
            Arrowhead.Obsidian => cost += 5,
            Arrowhead.Wood => cost += 3,
            _ => cost += 3
        };

        cost += (float)(this._Shaft * 0.05);

        cost = this._Fletching switch
        {
            Fletching.Goose => cost += 3,
            Fletching.Plastic => cost += 10,
            Fletching.Turkey => cost += 5,
            _ => cost += 3
        };
        
        return cost;
    }

    public static Arrow CreateEliteArrow() => new Arrow() { _Arrowhead = Arrowhead.Steel,
        _Fletching = Fletching.Plastic, _Shaft = 95};

    public static Arrow CreateBeginnerArrow() => new Arrow() { _Arrowhead = Arrowhead.Wood,
        _Fletching = Fletching.Goose, _Shaft = 75 };
    
    public static Arrow CreateMarksmanArrow() => new Arrow() { _Arrowhead = Arrowhead.Steel,
        _Fletching = Fletching.Goose, _Shaft = 65 };
    
}


enum Arrowhead {Steel, Wood, Obsidian};
enum Fletching {Plastic, Turkey, Goose};

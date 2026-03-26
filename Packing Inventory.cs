
Pack mypack = new Pack();

while (true)
{
    mypack.ShowPack();
    Console.WriteLine("_________________________");
    Console.WriteLine(mypack.ToString());
    mypack.ItemAdding();
}


public class Pack
{
    public double MaxWeight { get; private set; }
    public double MaxVolume { get; private set; }
    public int MaxItems { get; private set; }
    public InventoryItem[] Items { get; set; }

    public Pack()
    {
        Console.WriteLine("Write weight, volume, and item capacity.");
        MaxWeight = Convert.ToDouble(Console.ReadLine());
        MaxVolume = Convert.ToDouble(Console.ReadLine());
        MaxItems = Convert.ToInt32(Console.ReadLine());
        Items = new InventoryItem[MaxItems];
    }

    public double CalculateWeight()
    {
        double w = 0;
        foreach(var item in Items)
        {
            if (item != null) w += item.Weight;
        }
        return w;
    }

    public double CalculateVolume()
    {
        double v = 0;
        foreach (var item in Items)
        {
            if (item != null) v += item.Volume;
        }
        return v;
    }

    public int CalculateItems()
    {
        int i = 0;
        foreach (var item in Items)
        {
            if (item != null) i++;
        }
        return i;
    }

    public void ShowPack()
    {
        Console.WriteLine($"Current weight: {CalculateWeight()}");
        Console.WriteLine($"Current volume: {CalculateVolume()}");
        Console.WriteLine($"Current items count: {CalculateItems()}");
        Console.WriteLine($"Max weight: {MaxWeight}");
        Console.WriteLine($"Max volume: {MaxVolume}");
        Console.WriteLine($"Max items: {MaxItems}");
    }
    
    public bool Add(InventoryItem item)
    {
       bool result = (CalculateWeight()+item.Weight) <= MaxWeight && (CalculateVolume()+item.Volume) <= MaxVolume &&
                     CalculateItems() <= MaxItems-1;
       if (result)
       {
           Items[CalculateItems()] = item;
       }
       else
       {
           Console.WriteLine($"You can not add {item}");
       }
       
       return result;
    }
    
    public void ItemAdding()
    {
        Console.Write("1-Arrow, 2-Bow, 3-Rope, 4-Water, 5-Food, 6-Sword");
        Console.Write("Enter item number: ");
        int itemNumber = Convert.ToInt32(Console.ReadLine());
        switch (itemNumber)
        {
            case 1: Add(new Arrow()); break;
            case 2: Add(new Bow()); break;
            case 3: Add(new Rope()); break;
            case 4: Add(new Water()); break;
            case 5: Add(new Food()); break;
            case 6: Add(new Sword()); break;
            default: Console.WriteLine("Invalid item number"); break;
        }
    }

    public override string ToString()
    {
        string x = "Pack containing";
        foreach (var item in Items)
        {
            x += $" {item}";
        }
        return x;
    }
    
}



public class InventoryItem
{
    public double Weight { get; protected set; }
    public double Volume { get; protected set; }
    
}

public class Arrow : InventoryItem
{
    public Arrow()
    {
        Weight = 0.1;
        Volume = 0.05;
    }

    public override string ToString()
    {
        return "Arrow";
    }
}

public class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1.0;
        Volume = 4.0;
    }   
    public override string ToString()
    {
        return "Bow";
    }
}

public class Rope : InventoryItem
{
    public Rope()
    {
        Weight = 1.0;
        Volume = 1.5;
    }
    public override string ToString()
    {
        return "Rope";
    }
}

public class Water : InventoryItem
{
    public Water()
    {
        Weight = 2.0;
        Volume = 3.0;
    }
    public override string ToString()
    {
        return "Water";
    }
}

public class Food : InventoryItem
{
    public Food()
    {
        Weight = 1.0;
        Volume = 0.5;
    }
    public override string ToString()
    {
        return "Food";
    }
}

public class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5.0;
        Volume = 3.0;
    }
    public override string ToString()
    {
        return "Sword";
    }
}

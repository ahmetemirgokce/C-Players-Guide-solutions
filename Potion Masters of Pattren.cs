
Potions myPotion = Potions.Water;

while (true)
{
    Console.WriteLine($"Currently you have a {myPotion.ToString()} potion.");
    Console.WriteLine("You can add: Stardust, Snake Venom, Dragon Breath, Shadow Glass or Eyeshine Gem");
    Console.WriteLine("Or you can finish brewing by typing 'stop'");
    string? input = Console.ReadLine();
    if (input == "stop") break;
    myPotion = CraftPotion(myPotion, PickIngredients(input));
    if (myPotion == Potions.Ruined)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You have crafted a ruined potion. Start over with water.");
        myPotion = Potions.Water;
    }

    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("_________________________________________________________________________________");
}



Ingredients PickIngredients(string? input)
{
    return input switch
    {
        "stardust" => Ingredients.Stardust,
        "snake venom" => Ingredients.SnakeVenom,
        "dragon breath" => Ingredients.DragonBreath,
        "shadow glass" => Ingredients.ShadowGlass,
        "eyeshine gem" => Ingredients.EyeshineGem,
        _ => Ingredients.Nothing
    };
}

Potions CraftPotion(Potions potions, Ingredients ingredients)
{
    return (potions, ingredients) switch
    {
        (Potions p, Ingredients.Nothing) => p,
        (Potions.Water, Ingredients.Stardust) => Potions.Elixir,
        (Potions.Elixir,Ingredients.SnakeVenom) => Potions.Poison,
        (Potions.Elixir, Ingredients.DragonBreath) => Potions.Flying,
        (Potions.Elixir, Ingredients.EyeshineGem) => Potions.NightSight,
        (Potions.Elixir, Ingredients.ShadowGlass) => Potions.Invisibility,
        (Potions.NightSight, Ingredients.ShadowGlass) => Potions.Cloudy,
        (Potions.Cloudy, Ingredients.Stardust) => Potions.Wraith,
        _ => Potions.Ruined,
    };
}


enum Ingredients {Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem, Nothing}
enum Potions {Water, Elixir, Poison, Flying, Invisibility, NightSight, Cloudy, Wraith, Ruined}

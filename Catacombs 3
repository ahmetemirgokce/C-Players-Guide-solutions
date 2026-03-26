
void CreateDeck()
{
    for (int i = 0; i < 14; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Card card = new Card((Color)j, (Rank)i);
            Console.WriteLine($"The {card.Color} {card.Rank}");
        }
    }
}

Card Red10 = new Card(Color.Red, Rank.Ten);
Card RedDollar = new Card(Color.Red, Rank.Dollar);
Red10.CardType();
RedDollar.CardType();
Console.WriteLine("________________________________________________");

CreateDeck();


public class Card
{
    public Rank Rank { get; }
    public Color Color { get; }

    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }

    public Card(Color color)
    {
        Color = color;
    }

    public void CardType()
    {
        if((int)Rank < 10) Console.WriteLine("Number Card");
        else Console.WriteLine("Symbol Card");
    }
}

public enum Rank {One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Hat, Ampersand };
public enum  Color { Red, Blue, Green, Yellow}

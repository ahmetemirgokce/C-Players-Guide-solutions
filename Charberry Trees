CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class CharberryTree
{
    public event Action<CharberryTree>? Ripened;
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public void MaybeGrow()
    {
// Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke(this);
        }
    }
}

public class Notifier
{
    private void OnRipened(CharberryTree tree) => Console.WriteLine("A charberry fruit has ripened!");

    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened;
    }
    
}

public class Harvester
{
    private static void HandleRipened(CharberryTree tree) => tree.Ripe = false;

    public Harvester(CharberryTree tree)
    {
        tree.Ripened += HandleRipened;
    }
}

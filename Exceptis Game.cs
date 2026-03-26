cookieException();

void cookieException()
{
    Random random = new Random();
    int oatmeal = random.Next(10);
    List<int> choices = new List<int>();

    while (true)
    {
        try
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 0 || choice > 9)
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            if (choices.Contains(choice))
            {
                Console.WriteLine("This cookie is already selected");
                continue;
            }

            choices.Add(choice);

            if (choice == oatmeal) throw new GameException();
        }

        catch (GameException)
        {
            Console.WriteLine("YOU LOSE!");
            break;
        }
        
    }
}


public class GameException : Exception
{
    public GameException() {}
    public GameException(string message) : base(message) {}
}

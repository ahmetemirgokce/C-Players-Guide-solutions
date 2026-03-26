
RecentNumbers recentNumbers = new RecentNumbers();
Thread thread = new Thread(recentNumbers.Stream);
thread.Start();
while (true)
{
    recentNumbers.UserCheck();
}

public class RecentNumbers
{
    private readonly object _numberLock = new object(); 
    private int Number1 { get; set; }
    private int Number2 { get; set; }

    public void Stream()
    {
        Random rnd = new Random();
        
        while(true)
        {
            lock (_numberLock)
            {
                Number1 = rnd.Next(0, 9);
                Number2 = rnd.Next(0, 9);
                Thread.Sleep(1000);
                Console.WriteLine($"{Number1}, {Number2}");
            }
            
        }
    }

    public void UserCheck()
    {
        int a = Number1, b = Number2;
        if (Console.ReadKey() != null)
        {
            if (a == b)
                Console.WriteLine("Correct!");
            else 
                Console.WriteLine("Wrong!");
        }
        
    }
}

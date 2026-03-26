
while (true)
{
    string? word = Console.ReadLine();
    if (word == null) continue;
    if (word == "break") break;
    CreateTask(word);
}

async Task CreateTask(string word)
{
    Task<int> task = RandomlyRecreateAsync(word);
    Console.WriteLine(await task);
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() =>  RandomlyRecreate(word));
}

int RandomlyRecreate(string word)
{
    int length = word.Length;
    Random rnd = new Random();
    int attempts = 1;
    string randomWord = "";

    while (true)
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < length; i++)
        {
            randomWord += (char)('a' + rnd.Next(26));
        }

        if (randomWord == word)
        {
            DateTime end = DateTime.Now;
            Console.WriteLine($"It took {(end - start).TotalMilliseconds} milliseconds");
            break;
        }
        
        attempts++;
        randomWord = "";
    }

    return attempts;
}


int[] given = {1, 9, 2, 8, 3, 7, 4, 6, 5};

IEnumerable<int> filter2 = from i in given
    where i % 2 == 0
    orderby i
    select i * 2;

IEnumerable<int> filter3 = given
    .Where(i => i % 2 == 0)
    .OrderBy(i => i)
    .Select(i => i * 2);

foreach (int i in Filter1(given))
{
    Console.Write(i + ", ");
}
Console.WriteLine("\n");

foreach (int i in filter2)
{
    Console.Write(i + ", ");
}
Console.WriteLine("\n");

foreach (int i in filter3)
{
    Console.Write(i + ", ");
}


List<int> Filter1(int[] array)
{
    List<int> list1 = new List<int>();
    
    foreach (int x in array)
    {
        if(x % 2 == 0) list1.Add(x);
    }
    
    int length = list1.Count;
    
    for (int i = 0; i < length - 1; i++)
    {
        for (int j = i + 1; j < length; j++)
        {
            if (list1[i] > list1[j])
            {
                (list1[i], list1[j]) = (list1[j], list1[i]);
            }
        }
    }
    
    List<int> result = new List<int>();
    foreach (int x in list1)
    {
        result.Add(x * 2);
    }
    
    return result;
}

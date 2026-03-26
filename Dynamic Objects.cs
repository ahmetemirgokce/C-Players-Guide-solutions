using System.Dynamic;

{
   int id = 1;
   
   while (true)
   {
      dynamic robot = new ExpandoObject();
      robot.Id = id;
      id++;
      
      Console.WriteLine("Do you want to name this robot?");
      string input = Console.ReadLine();
      if (input == "yes")
      {
         robot.Name = Console.ReadLine();
      }
      
      Console.WriteLine("Does this robot have a specific size?");
      input = Console.ReadLine();
      if (input == "yes")
      {
         Console.WriteLine("What is its height?");
         robot.Height = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("What is its weight?");
         robot.Weight = Convert.ToInt32(Console.ReadLine());
      }
      
      Console.WriteLine("Does this robot have a specific color?");
      input = Console.ReadLine();
      if (input == "yes")
      {
         robot.Color = Console.ReadLine();
      }
      
      foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot) 
         Console.WriteLine($"{property.Key}: {property.Value}");
      Console.WriteLine("___________________________________________________________________________________");
   }
}


/*
DateTime startTime = DateTime.Now;
DateTime endTime = DateTime.Now;

Console.WriteLine(Add(1, 2));
Console.WriteLine(Add(1.0, 2.5));
Console.WriteLine(Add("an", "an"));
Console.WriteLine(Add(startTime.Second, endTime.Second));
*/

// using Generics would be better
dynamic Add(dynamic a, dynamic b)
{
   return a + b;
}


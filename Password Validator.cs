
while (true)
{
    Console.WriteLine("please enter a password:");
    Passwords newPass = new Passwords();
    Console.WriteLine(Passwords.PasswordValidator(newPass));
}

public class Passwords
{
    public string Password { get; }

    public Passwords()
    {
        Console.Write("Enter your password: ");
        Password = Console.ReadLine();
    }

    public static bool PasswordValidator(Passwords password)
    {
        bool upper = false;
        bool lower = false;
        bool number = false;
        int i = 0;
        foreach (char letter in password.Password)
        {
            i++;
            if (letter == 'T' || letter == '&') return false;
            upper = (upper || char.IsUpper(letter));
            lower = (lower || char.IsLower(letter));
            number = (number || char.IsDigit(letter));
        }
        // length check
        if(i < 6 || i > 13) return false;
        return (upper && lower && number);
    }
}

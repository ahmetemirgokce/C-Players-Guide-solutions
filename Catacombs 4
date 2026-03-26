
void MainDoor(Door door)
{
    while (true)
    {
        Console.WriteLine($"The door is {door.GetState()}");
        Door.ChangeState(door);
    }
}

Door door1 = new Door(State.Closed, 3169);
MainDoor(door1);

public class Door
{
    private State State { get; set; }
    private int Password { get; set; } = 0;

    public Door(State state, int password)
    {
        State = state;
        Password = password;
    }
    
    public State GetState() => State;

    public void ChangePassword()
    {
        Console.WriteLine("Enter the old password:");
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == Password)
        {
            Console.WriteLine("Enter the new password:");
            int newPassword = Convert.ToInt32(Console.ReadLine());
            Password = newPassword;
        }
    }

    public static void ChangeState(Door door)
    {
        string command = Console.ReadLine();
        if (door.State == State.Closed)
        {
            if (command.ToLower() == "lock") door.State = State.Locked;
            if (command.ToLower() == "open") door.State = State.Open;
        }
        if (door.State == State.Open && command.ToLower() == "close") door.State = State.Closed;
        if (door.State == State.Locked && command.ToLower() == "unlock")
        {
            Console.WriteLine("Please enter the password:");
            int entry = Convert.ToInt32(Console.ReadLine());
            if (entry == door.Password) door.State = State.Closed;
        }

        if (command.ToLower() == "change password") door.ChangePassword();
    }
}

public enum State {Open, Closed, Locked}

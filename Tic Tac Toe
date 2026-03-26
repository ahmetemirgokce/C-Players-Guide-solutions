
Board board = new Board();


while (true)
{
    board.Visual();
    board.Input(Tictactoe.X);
    if (board.WinCheck() != Tictactoe.Empty)
    {
        Console.WriteLine($"Player {board.WinCheck()} wins!");
        board.Visual();
        break;
    }
    board.Visual();
    board.Input(Tictactoe.O);
    if (board.WinCheck() != Tictactoe.Empty)
    {
        Console.WriteLine($"Player {board.WinCheck()} wins!");
        board.Visual();
        break;
    }
}


public class Board
{
    public static Tictactoe[,] GameBoard { get; internal set; } = InitializeBoard();
    public static Tictactoe PlayerX { get; } = Tictactoe.X;
    public static Tictactoe PlayerO { get; } = Tictactoe.O;
    
    
    // create a clear board
    public static Tictactoe[,] InitializeBoard()
    {
        Tictactoe[,] newBoard = new Tictactoe[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                newBoard[i, j] = Tictactoe.Empty;
            }
        }
        return newBoard;
    }
    
    
    public void Input(Tictactoe player)
    {
        Console.WriteLine($"It is {player}'s turn.");
        int x = AskNumber("", 0, 9);
        if (GameBoard[2 - ((x - 1) / 3), (x-1)%3] == Tictactoe.Empty) GameBoard[2 - ((x - 1) / 3), (x-1)%3] = player;
        else
        {
            Console.WriteLine("Invalid input.");
            Input(player);
        }
    }
    
    public static string Box(Tictactoe stuff)
    {
        if (stuff == Tictactoe.Empty) return " ";
        else if (stuff == Tictactoe.X) return "X";
        else return "O";
    }

    public void Visual()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("------------");
            Console.WriteLine($" {Box(GameBoard[i, 0])} | {Box(GameBoard[i, 1])} | {Box(GameBoard[i, 2])} ");
            Console.WriteLine("------------");
        }
    }

    public Tictactoe WinCheck()
    {
        Tictactoe x = Tictactoe.Empty;
        for (int i = 0; i < 3; i++)
        {
            //row check
            if (GameBoard[i, 0] != Tictactoe.Empty && GameBoard[i, 0] == GameBoard[i, 1] &&
                GameBoard[i, 1] == GameBoard[i, 2]) x = GameBoard[i, 0];
            
            // column check
            if (GameBoard[0, i] != Tictactoe.Empty && GameBoard[0, i] == GameBoard[1, i] &&
                GameBoard[i, i] == GameBoard[2, i]) x = GameBoard[0, i];
            
            //diagonal check
            if(GameBoard[0, 0] != Tictactoe.Empty && GameBoard[0, 0] == GameBoard[1, 1] &&
               GameBoard[1, 1] == GameBoard[2, 2]) x = GameBoard[0, 0];
            if (GameBoard[2, 0] != Tictactoe.Empty && GameBoard[2, 0] == GameBoard[1, 1] &&
                GameBoard[1, 1] == GameBoard[0, 2]) x = GameBoard[2, 0];}

        return x;
    }
        
    
    
    
    int AskNumber(string question, int min, int max)
    {
        while (true)
        {
            Console.Write(question);
            int number = Convert.ToInt32(Console.ReadLine());
            if (number < min || number > max)
            {
                Console.WriteLine("Invalid input");
                AskNumber(question, min, max);
            }
            return number;
        }
    }
}

public enum Tictactoe {Empty, O, X}

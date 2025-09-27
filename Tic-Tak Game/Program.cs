using System;

class TicTacToeGame
{
    static string[,] board = {
        { " ", " ", " " },
        { " ", " ", " " },
        { " ", " ", " " }
    };

    static void Main()
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        DisplayBoard();

        while (true)
        {
            PlayerMove();
            DisplayBoard();
            if (CheckWinner("X"))
            {
                Console.WriteLine("You win!");
                break;
            }

            if (IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                break;
            }

            ComputerMove();
            DisplayBoard();
            if (CheckWinner("O"))
            {
                Console.WriteLine("Computer wins!");
                break;
            }

            if (IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                break;
            }
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine("\nCurrent Board:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
            if (i < 2) Console.WriteLine("---|---|---");
        }
    }

    static void PlayerMove()
    {
        int row, col;
        while (true)
        {
            Console.Write("Enter your move (row and column: 0 1): ");
            string[] input = Console.ReadLine().Split();
            if (input.Length != 2 ||
                !int.TryParse(input[0], out row) ||
                !int.TryParse(input[1], out col) ||
                row < 0 || row > 2 || col < 0 || col > 2 ||
                board[row, col] != " ")
            {
                Console.WriteLine("Invalid move. Try again.");
            }
            else
            {
                board[row, col] = "X";
                break;
            }
        }
    }

    static void ComputerMove()
    {
        Random rand = new Random();
        int row, col;
        do
        {
            row = rand.Next(0, 3);
            col = rand.Next(0, 3);
        } while (board[row, col] != " ");

        board[row, col] = "O";
        Console.WriteLine($"Computer placed O at {row}, {col}");
    }

    static bool CheckWinner(string player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
        }
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

        return false;
    }

    static bool IsBoardFull()
    {
        foreach (string cell in board)
        {
            if (cell == " ") return false;
        }
        return true;
    }
}

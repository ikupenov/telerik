namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string PlayTurnCommand = "turn";
        private const string RestartGameCommand = "restart";
        private const string ExitGameCommand = "exit";
        private const string PrintLeaderboardCommand = "top";

        private const string HorizontalFieldBorder = "   ---------------------";
        private const string VerticalFieldBorder = "|";
        private const string FieldColumnsString = "    0 1 2 3 4 5 6 7 8 9";

        private const char MineCellSymbol = '*';
        private const char EmptyCellSymbol = '-';
        private const char UnknownCellSymbol = '?';

        private const int FieldRows = 5;
        private const int FieldCols = 10;

        private const int TotalMinesToPlace = 15;
        private const int MaxPossibleTurns = 35;

        private const int LeaderboardSize = 5;

        private static void Main()
        {
            string command = string.Empty;

            char[,] gamingField = CreateGamingField();
            char[,] minesField = CreateMineField();

            int turnsCount = 0;

            var leaderboard = new List<Player>(LeaderboardSize + 1);

            int row = 0;
            int col = 0;

            bool mineIsTriggered = false;
            bool isWinner = false;

            bool shouldStartGame = true;

            do
            {
                if (shouldStartGame)
                {
                    Console.WriteLine("Commands: \n'top': Shows leaderboard \n'restart': Restarts the game \n'exit': Exits the game");

                    DrawField(gamingField);
                    shouldStartGame = false;
                }

                Console.Write("Enter row and column: ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    bool isFirstCommandParsed = int.TryParse(command[0].ToString(), out row);
                    bool isSecondCommandParsed = int.TryParse(command[2].ToString(), out col);

                    bool isRowInValidRange = row <= gamingField.GetLength(0);
                    bool isColInValidRange = col <= gamingField.GetLength(1);

                    if (isFirstCommandParsed && isSecondCommandParsed &&
                        isRowInValidRange && isColInValidRange)
                    {
                        command = PlayTurnCommand;
                    }
                }

                switch (command)
                {
                    case PrintLeaderboardCommand:
                        PrintLeaderboard(leaderboard);
                        break;

                    case RestartGameCommand:
                        gamingField = CreateGamingField();
                        minesField = CreateMineField();

                        DrawField(gamingField);

                        mineIsTriggered = false;
                        shouldStartGame = false;
                        break;

                    case ExitGameCommand:
                        Console.WriteLine("Exitting game...");
                        break;

                    case PlayTurnCommand:
                        if (minesField[row, col] != MineCellSymbol)
                        {
                            if (minesField[row, col] == EmptyCellSymbol)
                            {
                                PlayTurn(gamingField, minesField, row, col);
                                turnsCount++;
                            }

                            if (MaxPossibleTurns == turnsCount)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                DrawField(gamingField);
                            }
                        }
                        else
                        {
                            mineIsTriggered = true;
                        }

                        break;

                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (mineIsTriggered)
                {
                    DrawField(minesField);

                    Console.Write("\nGame Over! - {0} points. " + "Enter your nickname: ", turnsCount);

                    string nickname = Console.ReadLine();
                    var player = new Player(nickname, turnsCount);

                    if (leaderboard.Count < LeaderboardSize)
                    {
                        leaderboard.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < leaderboard.Count; i++)
                        {
                            if (leaderboard[i].Points < player.Points)
                            {
                                leaderboard.Insert(i, player);
                                leaderboard.RemoveAt(leaderboard.Count - 1);

                                break;
                            }
                        }
                    }

                    leaderboard.Sort((Player p1, Player p2) => p2.Name.CompareTo(p1.Name));
                    leaderboard.Sort((Player p1, Player p2) => p2.Points.CompareTo(p1.Points));

                    PrintLeaderboard(leaderboard);

                    gamingField = CreateGamingField();
                    minesField = CreateMineField();

                    turnsCount = 0;

                    mineIsTriggered = false;
                    shouldStartGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nGood job! You've sweeped all mines possible [{0}].", MaxPossibleTurns);

                    DrawField(minesField);

                    Console.WriteLine("Enter your nickname: ");

                    string nickname = Console.ReadLine();
                    var player = new Player(nickname, turnsCount);

                    leaderboard.Add(player);
                    PrintLeaderboard(leaderboard);

                    gamingField = CreateGamingField();
                    minesField = CreateMineField();

                    turnsCount = 0;

                    isWinner = false;
                    shouldStartGame = true;
                }
            }
            while (command != ExitGameCommand);

            Console.Read();
        }

        private static void PrintLeaderboard(List<Player> allPlayers)
        {
            if (allPlayers.Count > 0)
            {
                Console.WriteLine("\nScore:");

                for (int i = 0; i < allPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} turns", i + 1, allPlayers[i].Name, allPlayers[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The leaderboard is empty!\n");
            }
        }

        private static void PlayTurn(char[,] gamingField, char[,] minesField, int row, int col)
        {
            char minesCount = GetMinesCount(minesField, row, col);

            minesField[row, col] = minesCount;
            gamingField[row, col] = minesCount;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n{0}", FieldColumnsString);
            Console.WriteLine(HorizontalFieldBorder);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} {1} ", i, VerticalFieldBorder);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write(VerticalFieldBorder);
                Console.WriteLine();
            }

            Console.WriteLine(HorizontalFieldBorder + "\n");
        }

        private static char[,] CreateGamingField()
        {
            var gamingField = new char[FieldRows, FieldCols];

            for (int i = 0; i < FieldRows; i++)
            {
                for (int j = 0; j < FieldCols; j++)
                {
                    gamingField[i, j] = UnknownCellSymbol;
                }
            }

            return gamingField;
        }

        private static char[,] CreateMineField()
        {
            var mineField = new char[FieldRows, FieldCols];

            for (int i = 0; i < FieldRows; i++)
            {
                for (int j = 0; j < FieldCols; j++)
                {
                    mineField[i, j] = EmptyCellSymbol;
                }
            }

            var generatedMines = new List<int>();

            while (generatedMines.Count < TotalMinesToPlace)
            {
                var randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(50);

                if (!generatedMines.Contains(randomNumber))
                {
                    generatedMines.Add(randomNumber);
                }
            }

            foreach (var mine in generatedMines)
            {
                int row = mine / FieldCols;
                int col = mine % FieldCols;

                if (col == 0 && mine != 0)
                {
                    col = FieldCols;
                    row--;
                }
                else
                {
                    col++;
                }

                mineField[row, col - 1] = MineCellSymbol;
            }

            return mineField;
        }

        private static char GetMinesCount(char[,] field, int currentRow, int currentCol)
        {
            int minesCounter = 0;

            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (field[currentRow - 1, currentCol] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (field[currentRow + 1, currentCol] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (field[currentRow, currentCol - 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (field[currentRow, currentCol + 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (field[currentRow - 1, currentCol - 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (field[currentRow - 1, currentCol + 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (field[currentRow + 1, currentCol - 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (field[currentRow + 1, currentCol + 1] == MineCellSymbol)
                {
                    minesCounter++;
                }
            }

            return char.Parse(minesCounter.ToString());
        }
    }
}
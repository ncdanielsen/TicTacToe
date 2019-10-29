using System;

namespace TicTacToe
{
    class Program
    {


        static GameInstance game;

        static void Main(string[] args)
        {
            bool wouldLikeToPlay = true;
            do
            {
                StartGame();
                PlayGame();
                EndGame();
                Console.WriteLine("Would you like to play again?");
                bool properInput = false;
                do
                {
                    Console.WriteLine("y/n?");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        wouldLikeToPlay = true;
                        properInput = true;
                    }
                    else if (input == "n")
                    {
                        wouldLikeToPlay = false;
                        properInput = true;
                    }
                    else
                        properInput = false;
                } while (!properInput);
                
            } while (wouldLikeToPlay);
            Console.WriteLine("Thank you for playing");
            
        }

        static public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Press enter to start game");
            Console.ReadLine();
            game = new GameInstance();
        }
        static public void PlayGame()
        {
            int input;
            while (!game.HasWinner && !game.IsDraw)
            {
                Console.Clear();
                VisualDisplay();
                bool properInput;
                do
                {
                    input = GetInput();
                    properInput = game.SetMarker(input);
                } while (!properInput);
                
                if(game.GetPlayerTurn() > 3)
                {
                    game.HasWinner = game.CheckForWin();
                }
                game.IncrementTurn();
                if (game.GetPlayerTurn() > 8 && !game.HasWinner)
                    game.IsDraw = true;
            }
        }

        private static int GetInput()
        {
            bool conversion;
            int number;
            do
            {
                string input = Console.ReadLine();
                conversion = Int32.TryParse(input, out number);
                if (conversion == false)
                    Console.WriteLine("Type in a proper number!");
                else if (number < 1 || number > 9)
                    Console.WriteLine("Type in a number between 1 and 9!");
            } while (!conversion);        
            return number - 1;
        }

        static public void EndGame()
        {
            Console.Clear();
            VisualDisplay();
            if (game.IsDraw)
            {
                Console.WriteLine("It was a draw!");
            }
            else
            {
                string player;
                if ((game.GetPlayerTurn()-1) % 2 == 0)
                    player = "1";
                else
                    player = "2";
                Console.WriteLine("Congratulations, player {0} won!", player);
            }
            
        }

        static public void VisualDisplay()
        {
            string[] board = game.GetLogicalBoard();
            string gameLine = " {0} | {1} | {2}";
            string breaker = "---|---|---";
            for (int i = 0; i < 8; i+=3)
            {
                Console.WriteLine(gameLine, board[i], board[i+1], board[i+2]);
                if(i < 6)
                {
                    Console.WriteLine(breaker);
                }

            }
            int turn = game.GetPlayerTurn();
            if(!(game.HasWinner || game.IsDraw))
            {
                if (turn % 2 == 0)
                    Console.WriteLine("Player 1 turn");
                else
                    Console.WriteLine("Player 2 turn");
                Console.WriteLine("Please enter a number:");
            }
            
            
            
        }

    }
}

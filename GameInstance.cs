using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameInstance
    {
        string[] logicalBoard;
        int playerTurn;
        bool hasWinner;
        bool isDraw;

        public bool HasWinner { get => hasWinner; set => hasWinner = value; }
        public bool IsDraw { get => isDraw; set => isDraw = value; }

        public GameInstance()
        {
            playerTurn = 0;
            logicalBoard = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        }

        public string[] GetLogicalBoard()
        {
            return logicalBoard;
        }

        public bool SetMarker(int position)
        {
            if(logicalBoard[position] == "X" || logicalBoard[position] == "O")
            {
                Console.WriteLine("Position was picked before!");
                Console.WriteLine("Enter new number:");
                return false;
            }
            else
            {
                if (playerTurn % 2 == 0)
                    logicalBoard[position] = "X";
                else
                    logicalBoard[position] = "O";
                return true;
            }

        }

        public void IncrementTurn()
        {
            playerTurn++;
        }

        public int GetPlayerTurn()
        {
            return playerTurn;
        }

        public bool CheckForWin()
        {
            string marker;
            if (playerTurn % 2 == 0)
                marker = "X";
            else
                marker = "O";

            if (logicalBoard[0] == marker && logicalBoard[1] == marker && logicalBoard[2] == marker)
                return true;
            else if (logicalBoard[3] == marker && logicalBoard[4] == marker && logicalBoard[5] == marker)
                return true;
            else if (logicalBoard[6] == marker && logicalBoard[7] == marker && logicalBoard[8] == marker)
                return true;
            else if (logicalBoard[0] == marker && logicalBoard[3] == marker && logicalBoard[6] == marker)
                return true;
            else if (logicalBoard[1] == marker && logicalBoard[4] == marker && logicalBoard[7] == marker)
                return true;
            else if (logicalBoard[2] == marker && logicalBoard[5] == marker && logicalBoard[8] == marker)
                return true;
            else if (logicalBoard[0] == marker && logicalBoard[4] == marker && logicalBoard[8] == marker)
                return true;
            else if (logicalBoard[2] == marker && logicalBoard[4] == marker && logicalBoard[6] == marker)
                return true;
            else
                return false;
        }
    }
}

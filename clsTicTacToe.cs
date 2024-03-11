using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class clsTicTacToe
    {
        /// <summary>
        /// board of strings to help define a winning move
        /// </summary>
        private string[,] saBoard;

        /// <summary>
        /// keeps track of player1 wins
        /// </summary>
        private int iPlayer1Wins;

        /// <summary>
        /// keeps track of player2 wins
        /// </summary>
        private int iPlayer2Wins;

        /// <summary>
        /// keeps track of ties
        /// </summary>
        private int iTies;

        /// <summary>
        /// allows for allocating a winning
        /// move by row, column, or diag
        /// </summary>
        private WinningMove eWinningMove;

        /// <summary>
        /// defines what row, column, or diag is
        /// a winning move
        /// </summary>
        public enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        /// <summary>
        /// constructor, sets board and initalizes variables
        /// </summary>
        public clsTicTacToe()
        {
            //set board to 3 by 3 string
            saBoard = new string[3, 3];
            //outer loop for rows
            for(int i = 0; i < 3; i++)
            {
                //inner loop for columns
                for(int j = 0; j < 3; j++)
                {
                    saBoard[i, j] = " ";
                }
            }
            //set player and ties to 0
            iPlayer1Wins = 0;
            iPlayer2Wins = 0;
            iTies = 0;
        }
        #region

        //properties
        /// <summary>
        /// getter/setter for player1Wins
        /// </summary>
        public int Player1Wins
        {
            get { return iPlayer1Wins; }
            set { iPlayer1Wins = value;}
        }

        /// <summary>
        /// getter/setter for player2Wins
        /// </summary>
        public int Player2Wins
        {
            get { return iPlayer2Wins; }
            set { iPlayer2Wins = value; }
        }

        /// <summary>
        /// getter/setter for iTies
        /// </summary>
        public int Ties
        {
            get { return iTies; }
            set { iTies = value; }
        }

        /// <summary>
        /// getter/setter for the saBoard
        /// </summary>
        public string[,] GetSetBoard
        {
            get { return saBoard; }
            set { saBoard = value; }
        }

        /// <summary>
        /// gets the winningMove from the board/enumeration
        /// </summary>
        public WinningMove GetWinningMove
        {
            get { return eWinningMove; }
        }
        #endregion

        /// <summary>
        /// determines if there has been
        /// a winning move played
        /// </summary>
        /// <returns></returns>
        public bool isWinningMove()
        {
            return isHor() || isVert() || isDiag();
        }

        /// <summary>
        /// determines if there is a horizontal
        /// winning move for the 3 rows
        /// </summary>
        /// <returns></returns>
        private bool isHor()
        {
            //loop through
            for(int i = 0; i < 3; i++)
            {
                //determine if the row is all the same
                if (saBoard[i,0] == saBoard[i,1] && saBoard[i,1] == saBoard[i,2] && saBoard[i,0] != " ")
                {
                    //switch/case for winningmoves in rows
                    switch (i)
                    {
                        case 0:
                            eWinningMove = WinningMove.Row1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Row2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Row3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// determines if there is a vertical
        /// winning move for the 3 columns
        /// </summary>
        /// <returns></returns>
        private bool isVert()
        {
            //loop through for columns
            for(int i = 0; i < 3; i++)
            {
                //determine if the column have the same values
                if (saBoard[0, i] == saBoard[1, i] && saBoard[1, i] == saBoard[2, i] && saBoard[0,i] != " ")
                {
                    //switch/case for winningmoves in columns
                    switch (i)
                    {
                        case 0:
                            eWinningMove = WinningMove.Col1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Col2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Col3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// determines if there is a diagonal
        /// winning move for the 2 diagonals
        /// </summary>
        /// <returns></returns>
        private bool isDiag()
        {
            //if right diagonal
            if (saBoard[0,0] == saBoard[1,1] && saBoard[1, 1] == saBoard[2,2] && saBoard[0,0] != " ")
            {
                //set to winning move
                eWinningMove = WinningMove.Diag1;
                return true;
            }
            //if left  diagonal
            if (saBoard[0,2] == saBoard[1,1] && saBoard[1,1] == saBoard[2,0] && saBoard[0,2] != " ")
            {
                //set to winning move
                eWinningMove = WinningMove.Diag2;
                return true;
            }
            return false;
        }

        /// <summary>
        /// determines if a tie has been met
        /// and has no winning move
        /// </summary>
        /// <returns></returns>
        public bool isTie()
        {
            //nested for loops to go through board
            for(int i = 0; i < 3; i++) // rows
            {
                for(int j = 0; j < 3; j++) // columns
                {
                    //determines if no values line up for winning move
                    if (saBoard[i, j] == " ")
                    {
                        return false;
                    }
                }
            }
            return !isWinningMove();
        }
    }
}

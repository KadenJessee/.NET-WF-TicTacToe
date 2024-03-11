using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// instance of class TicTacToe
        /// </summary>
        clsTicTacToe TicTacToe;
        /// <summary>
        /// determines if the game has started
        /// </summary>
        bool bHasGameStarted;
        /// <summary>
        /// determines which players turn it is
        /// </summary>
        int playerTurn;



        public MainWindow()
        {
            InitializeComponent();
            TicTacToe = new clsTicTacToe();
            playerStatus.Content = "Click start to begin";
        }

        /// <summary>
        /// When user clicks start, the gameboard
        /// resets all colors and labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //bHasGameStarted
            bHasGameStarted = true;
            playerTurn = 1;
            //ResetColors
            ResetColors();
            //ResetLabels
            ResetLabels();
        }

        /// <summary>
        /// player clicks a spot and it's updated
        /// for the ticTacToe game, doesn't allow user
        /// to click on a taken spot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, MouseButtonEventArgs e)
        {
            //bHasGameStarted
            if (!bHasGameStarted)
            {
                return;
            }

            //determine which label is being clicked on
            Label clickedLabel = (Label)sender;

            //empty
            if (clickedLabel.Content != " ")//if not empty
            {
                return;
            }
            //set
            //if player 1 turn
            if(playerTurn== 1)
            {
                clickedLabel.Content = "X"; //change label to X
                clickedLabel.Foreground = new SolidColorBrush(Colors.Red); //change color to red
                playerTurn = 2;
                //update player status
                playerStatus.Content = "Player " + playerTurn + "'s turn";
            }
            else//if player 2 turn
            {
                clickedLabel.Content = "O"; // change label to O
                clickedLabel.Foreground = new SolidColorBrush(Colors.Blue); //change color to blue
                playerTurn = 1;
                playerStatus.Content = "Player " + playerTurn + "'s turn";
            }

            //LoadBoard
            LoadBoard();


            //IsWinningMove
            if (TicTacToe.isWinningMove())
            {
                //HighlightWinningMove
                HighLightWinningMove();
                //UpdateStats
                UpdateStats();
                //bHasGameStarted
                bHasGameStarted = false;
            }

            //isTie
            if (TicTacToe.isTie())
            {
                //UpdateStats
                UpdateStats();
                //bHasGameStarted
                bHasGameStarted = false;
            }
        }


        /// <summary>
        /// Resets the colors of the board
        /// </summary>
        private void ResetColors()
        {
            lbl00.Background = new SolidColorBrush(Colors.Gray);
            lbl01.Background = new SolidColorBrush(Colors.Gray);
            lbl02.Background = new SolidColorBrush(Colors.Gray);

            lbl10.Background = new SolidColorBrush(Colors.Gray);
            lbl11.Background = new SolidColorBrush(Colors.Gray);
            lbl12.Background = new SolidColorBrush(Colors.Gray);

            lbl20.Background = new SolidColorBrush(Colors.Gray);
            lbl21.Background = new SolidColorBrush(Colors.Gray);
            lbl22.Background = new SolidColorBrush(Colors.Gray);
        }


        /// <summary>
        /// Clears the boards labels
        /// </summary>
        private void ResetLabels()
        {
            //for the board
            lbl00.Content = " ";
            lbl01.Content = " ";
            lbl02.Content = " ";

            lbl10.Content = " ";
            lbl11.Content = " ";
            lbl12.Content = " ";

            lbl20.Content = " ";
            lbl21.Content = " ";
            lbl22.Content = " ";

            //update the player status label
            playerStatus.Content = "Player " + playerTurn + "'s turn";
        }

        /// <summary>
        /// sets the private saBoard to the values
        /// from the game
        /// </summary>
        private void LoadBoard()
        {
            TicTacToe.GetSetBoard[0, 0] = lbl00.Content.ToString();
            TicTacToe.GetSetBoard[0, 1] = lbl01.Content.ToString();
            TicTacToe.GetSetBoard[0, 2] = lbl02.Content.ToString();

            TicTacToe.GetSetBoard[1, 0] = lbl10.Content.ToString();
            TicTacToe.GetSetBoard[1, 1] = lbl11.Content.ToString();
            TicTacToe.GetSetBoard[1, 2] = lbl12.Content.ToString();

            TicTacToe.GetSetBoard[2, 0] = lbl20.Content.ToString();
            TicTacToe.GetSetBoard[2, 1] = lbl21.Content.ToString();
            TicTacToe.GetSetBoard[2, 2] = lbl22.Content.ToString();
        }

        /// <summary>
        /// highlights the winning move of the 
        /// given ticTacToe board
        /// </summary>
        private void HighLightWinningMove()
        {
            if(TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Row1) //highlight row 1
            {
                lbl00.Background = System.Windows.Media.Brushes.Yellow;
                lbl01.Background = System.Windows.Media.Brushes.Yellow;
                lbl02.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Row2)//highlight row 2
            {
                lbl10.Background = System.Windows.Media.Brushes.Yellow;
                lbl11.Background = System.Windows.Media.Brushes.Yellow;
                lbl12.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Row3)//highlight row 3
            {
                lbl20.Background = System.Windows.Media.Brushes.Yellow;
                lbl21.Background = System.Windows.Media.Brushes.Yellow;
                lbl22.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Col1)//highlight column1
            {
                lbl00.Background = System.Windows.Media.Brushes.Yellow;
                lbl10.Background = System.Windows.Media.Brushes.Yellow;
                lbl20.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Col2)//highlight column 2
            {
                lbl01.Background = System.Windows.Media.Brushes.Yellow;
                lbl11.Background = System.Windows.Media.Brushes.Yellow;
                lbl21.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Col3)//highlight column 3
            {
                lbl02.Background = System.Windows.Media.Brushes.Yellow;
                lbl12.Background = System.Windows.Media.Brushes.Yellow;
                lbl22.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Diag1)//highlight right diagonal
            {
                lbl00.Background = System.Windows.Media.Brushes.Yellow;
                lbl11.Background = System.Windows.Media.Brushes.Yellow;
                lbl22.Background = System.Windows.Media.Brushes.Yellow;
            }
            if (TicTacToe.GetWinningMove == clsTicTacToe.WinningMove.Diag2)//highlight left diagonal
            {
                lbl02.Background = System.Windows.Media.Brushes.Yellow;
                lbl11.Background = System.Windows.Media.Brushes.Yellow;
                lbl20.Background = System.Windows.Media.Brushes.Yellow;
            }
        }

        /// <summary>
        /// updates stats of players wins and ties
        /// </summary>
        private void UpdateStats()
        {
            //update the tie
            if (TicTacToe.isTie())
            {
                TicTacToe.Ties += 1;
                lblCountTies.Content = "Ties: " + TicTacToe.Ties;
                playerStatus.Content = "It's a tie!";
            }
            //if player 1 had just made their move and won, set the wins
            if(playerTurn == 2 && TicTacToe.isWinningMove())
            {
                TicTacToe.Player1Wins += 1;
                lblPlayer1Wins.Content = "Player 1 Wins: " + TicTacToe.Player1Wins;
                playerStatus.Content = "Player 1 wins!";
            }
            //else player 2, look at the logic for if playerturn == 1 or else statement
            else if (playerTurn == 1 && TicTacToe.isWinningMove()) 
            {
                TicTacToe.Player2Wins += 1;
                lblPlayer2Wins.Content = "Player 2 Wins: " + TicTacToe.Player2Wins;
                playerStatus.Content = "Player 2 wins!";
            }
        }
    }
}

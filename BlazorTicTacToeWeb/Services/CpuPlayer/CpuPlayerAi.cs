using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services.CpuPlayer
{
    /// <summary>
    /// CPU Player that tries to win the game
    /// </summary>
    public class CpuPlayerAi : ICpuPlayer
    {
        public GameBoardSquareModel ChooseMove(GameBoardModel gameBoard)
        {
            GameBoardSquareModel nextMove = null;
            if (IsFirstMove(gameBoard))
            {
                // prefer center of board
                nextMove = gameBoard.Squares[1][1].CurrentSquareValue == SquareValue.NotSet 
                    ? gameBoard.Squares[1][1] 
                    : gameBoard.Squares[0][0];
            }

            return nextMove;
        }

        public static bool IsFirstMove(GameBoardModel gameBoard)
        {
            var isFirstMove = true;
            var squaresTaken = 0;
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                if (!isFirstMove)
                {
                    break;
                }
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    if (gameBoard.Squares[i][j].CurrentSquareValue != SquareValue.NotSet)
                    {
                        squaresTaken++;
                        if (squaresTaken > 1)
                        {
                            isFirstMove = false;
                            break;
                        }
                    }
                }
            }
            return isFirstMove;
        }
    }
}
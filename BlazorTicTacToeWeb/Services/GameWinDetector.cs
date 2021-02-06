using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services
{
    public class GameWinDetector : IGameWinDetector
    {
        public SquareValue DetectWinner(GameBoardModel gameBoardModel)
        {
            SquareValue result = SquareValue.NotSet;
            var squares = gameBoardModel.Squares;
            SquareValue slantWin = HasSlantWin(squares);
            if (slantWin == SquareValue.NotSet)
            {
                SquareValue rowColWin = HasRowOrColumnWin(squares);
                if (rowColWin != SquareValue.NotSet)
                {
                    result = rowColWin;
                }
            }
            else
            {
                result = slantWin;
            }
            
            return result;
        }

        private SquareValue HasSlantWin(GameBoardSquareModel[][] squares)
        {
            SquareValue slantWin;
            if (squares[0][0].CurrentSquareValue != SquareValue.NotSet
                && squares[0][0].CurrentSquareValue == squares[1][1].CurrentSquareValue
                && squares[1][1].CurrentSquareValue == squares[2][2].CurrentSquareValue)
            {
                slantWin = squares[0][0].CurrentSquareValue;
            }
            else if (squares[0][2].CurrentSquareValue != SquareValue.NotSet
                && squares[0][2].CurrentSquareValue == squares[1][1].CurrentSquareValue
                && squares[1][1].CurrentSquareValue == squares[2][0].CurrentSquareValue)
            {
                slantWin = squares[1][1].CurrentSquareValue;
            }
            else
            {
                slantWin = SquareValue.NotSet;
            }
            return slantWin;
        }

        private SquareValue HasRowOrColumnWin(GameBoardSquareModel[][] squares)
        {
            SquareValue winningValue = SquareValue.NotSet;
            for (int i = 0; i < GameManager.NumRowsCols; i++)
            {
                int rowMatches = 0;
                int columnMatches = 0;
                for (int j = 0; j < GameManager.NumRowsCols; j++)
                {
                    var currentRowValue = squares[i][j].CurrentSquareValue;
                    var currentColumnValue = squares[j][i].CurrentSquareValue;
                    if (currentRowValue != SquareValue.NotSet
                        && currentRowValue == squares[i][1].CurrentSquareValue)
                    {
                        rowMatches++;
                    }
                    var columnCompareValue = squares[1][i].CurrentSquareValue;
                    if (currentColumnValue != SquareValue.NotSet 
                        && currentColumnValue == columnCompareValue)
                    {
                        columnMatches++;
                    }
                }
                if (rowMatches == GameManager.NumRowsCols)
                {
                    winningValue = squares[i][1].CurrentSquareValue;
                    break;
                } 
                else if (columnMatches == GameManager.NumRowsCols)
                {
                    winningValue = squares[1][i].CurrentSquareValue;
                    break;
                }
            }
            return winningValue;
        }
    }
}

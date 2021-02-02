﻿using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services
{
    public class GameWinDetector
    {
        public SquareValue DetectWinner(GameBoardModel gameBoardModel)
        {
            SquareValue result = SquareValue.NotSet;
            var squares = gameBoardModel.Squares;
            SquareValue rowColWin = HasRowOrColumnWin(squares);
            if (rowColWin != SquareValue.NotSet)
            {
                result = rowColWin;
            }
            return result;
        }

        private SquareValue HasRowOrColumnWin(GameBoardSquareModel[][] squares)
        {
            SquareValue winningValue = SquareValue.NotSet;
            for (int i = 0; i < GameManager.NUM_ROWS_COLS; i++)
            {
                int rowMatches = 0;
                int columnMatches = 0;
                for (int j = 0; j < GameManager.NUM_ROWS_COLS; j++)
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
                if (rowMatches == GameManager.NUM_ROWS_COLS)
                {
                    winningValue = squares[i][1].CurrentSquareValue;
                    break;
                } else if (columnMatches == GameManager.NUM_ROWS_COLS)
                {
                    winningValue = squares[1][i].CurrentSquareValue;
                    break;
                }
            }
            return winningValue;
        }
    }
}

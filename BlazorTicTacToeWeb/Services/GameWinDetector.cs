using System;
using System.Collections.Generic;
using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services
{
    public class GameWinDetector : IGameWinDetector
    {
        public SquareValue DetectWinner(GameBoardModel gameBoardModel)
        {
            var result = SquareValue.NotSet;
            var squares = gameBoardModel.Squares;
            var slantWin = HasSlantWin(squares);
            if (slantWin == SquareValue.NotSet)
            {
                var rowColWin = HasRowOrColumnWin(squares);
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

        public bool IsGameDraw(GameBoardModel gameBoardModel)
        {
            var isDraw = false;
            var totalSquares = (int) Math.Pow(GameManager.NumRowsCols, 2);
            var setSquares = 0;
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    if (gameBoardModel.Squares[i][j].CurrentSquareValue != SquareValue.NotSet)
                    {
                        setSquares++;
                    }
                }
            }

            if (totalSquares == setSquares)
            {
                isDraw = true;
            }

            return isDraw && DetectWinner(gameBoardModel) == SquareValue.NotSet;
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

        private static SquareValue HasRowOrColumnWin(IReadOnlyList<GameBoardSquareModel[]> squares)
        {
            var winningValue = SquareValue.NotSet;
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                var rowMatches = 0;
                var columnMatches = 0;
                for (var j = 0; j < GameManager.NumRowsCols; j++)
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
                if (columnMatches == GameManager.NumRowsCols)
                {
                    winningValue = squares[1][i].CurrentSquareValue;
                    break;
                }
            }

            return winningValue;
        }
    }
}
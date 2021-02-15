using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services.CpuPlayer
{
    /// <summary>
    /// CPU Player that makes moves randomly to
    /// an open square on the board
    /// </summary>
    public class CpuPlayerRandom : ICpuPlayer
    {
        private readonly Random _randomGenerator = new Random();

        public GameBoardSquareModel ChooseMove(GameBoardModel gameBoard)
        {
            var emptySquares = FindEmptySquares(gameBoard);
            if (!emptySquares.Any())
            {
                throw new InvalidOperationException("No empty spaces");
            }
            var maxIndex = emptySquares.Count() - 1;
            var index = _randomGenerator.Next(maxIndex);
            return emptySquares[index];
        }

        private static List<GameBoardSquareModel> FindEmptySquares(GameBoardModel gameBoard)
        {
            var emptySquares = new List<GameBoardSquareModel>();
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    var square = gameBoard.Squares[i][j];
                    if (square.CurrentSquareValue == SquareValue.NotSet)
                    {
                        emptySquares.Add(square);
                    }
                }
            }
            return emptySquares;
        }
    }
}

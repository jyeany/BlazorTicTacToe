using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using BlazorTicTacToeWeb.Services.CpuPlayer;
using System;
using Xunit;

namespace BlazorTicTacToeXUnit.Services.CpuPlayer
{
    public class CpuPlayerRandomTest
    {
        private readonly CpuPlayerRandom _randomPlayer = new CpuPlayerRandom();

        [Fact]
        public void ChooseMove_NoEmptySquares()
        {
            var argBoard = new GameBoardModel();
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    argBoard.Squares[i][j].CurrentSquareValue = SquareValue.O;
                }
            }

            Assert.Throws<InvalidOperationException>(
                () => _randomPlayer.ChooseMove(argBoard));
        }

        [Fact]
        public void ChooseMove_OneEmpty()
        {
            const int emptyRow = 1;
            const int emptyCol = 1;
            var argBoard = new GameBoardModel();
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    if (i == emptyRow && j == emptyCol)
                    {
                        argBoard.Squares[i][j].CurrentSquareValue = SquareValue.NotSet;
                    }
                    else
                    {
                        argBoard.Squares[i][j].CurrentSquareValue = SquareValue.X;
                    }
                }
            }

            var resultSquare = _randomPlayer.ChooseMove(argBoard);
            Assert.Equal(emptyRow, resultSquare.Row);
            Assert.Equal(emptyCol, resultSquare.Column);
            Assert.Equal(SquareValue.NotSet, resultSquare.CurrentSquareValue);
        }

        [Fact]
        public void ChooseMove_CornersEmpty()
        {
            var argBoard = new GameBoardModel();
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    argBoard.Squares[i][j].CurrentSquareValue =
                        IsCorner(argBoard.Squares[i][j])
                            ? SquareValue.NotSet
                            : SquareValue.O;
                }
            }

            var resultSquare = _randomPlayer.ChooseMove(argBoard);
            Assert.True(IsCorner(resultSquare));
            Assert.Equal(SquareValue.NotSet, resultSquare.CurrentSquareValue);
        }

        private static bool IsCorner(GameBoardSquareModel square) =>
            (square.Row == 0 && square.Column == 0)
            || (square.Row == 0 && square.Column == 2)
            || (square.Row == 2 && square.Column == 0)
            || (square.Row == 2 && square.Column == 2);
    }
}

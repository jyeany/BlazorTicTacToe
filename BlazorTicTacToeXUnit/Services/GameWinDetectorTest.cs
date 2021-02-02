using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Xunit;

namespace BlazorTicTacToeXUnit.Services
{
    public class GameWinDetectorTest
    {
        private GameWinDetector gameWinDetector = new GameWinDetector();

        [Fact]
        public void DetectWinner_EmptyBoard()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.NotSet, result);
        }

        [Fact]
        public void DetectWinner_FirstRow()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[0][1] = CreateSquareModelX();
            arg.Squares[0][2] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_SecondRow()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[1][0] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[1][2] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ThirdRow()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[2][0] = CreateSquareModelX();
            arg.Squares[2][1] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_FirstColumn()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[1][0] = CreateSquareModelX();
            arg.Squares[2][0] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_SecondColumn()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][1] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][1] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ThirdColumn()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][2] = CreateSquareModelX();
            arg.Squares[1][2] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ForwardSlant()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_BackSlant()
        {
            GameBoardModel arg = new GameBoardModel();
            GenerateEmptySquares(arg.Squares);
            arg.Squares[0][2] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][0] = CreateSquareModelX();
            SquareValue result = gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        private GameBoardSquareModel[][] GenerateEmptySquares(GameBoardSquareModel[][] squares)
        {
            for (int i = 0; i < GameManager.NUM_ROWS_COLS; i++)
            {
                for (int j = 0; j < GameManager.NUM_ROWS_COLS; j++)
                {
                    GameBoardSquareModel toAdd = new GameBoardSquareModel();
                    toAdd.CurrentSquareValue = SquareValue.NotSet;
                    squares[i][j] = toAdd;
                }
            }
            return squares;
        }

        private GameBoardSquareModel CreateSquareModelX()
        {
            var toReturn = new GameBoardSquareModel();
            toReturn.CurrentSquareValue = SquareValue.X;
            return toReturn;
        }
    }
}

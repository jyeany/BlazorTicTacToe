using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Xunit;

namespace BlazorTicTacToeXUnit.Services
{
    public class GameWinDetectorTest
    {
        private readonly GameWinDetector _gameWinDetector = new GameWinDetector();

        [Fact]
        public void DetectWinner_EmptyBoard()
        {
            var arg = new GameBoardModel();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.NotSet, result);
        }

        [Fact]
        public void DetectWinner_FirstRow()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[0][1] = CreateSquareModelX();
            arg.Squares[0][2] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_SecondRow()
        {
            var arg = new GameBoardModel();
            arg.Squares[1][0] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[1][2] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ThirdRow()
        {
            var arg = new GameBoardModel();
            arg.Squares[2][0] = CreateSquareModelX();
            arg.Squares[2][1] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_FirstColumn()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[1][0] = CreateSquareModelX();
            arg.Squares[2][0] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_SecondColumn()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][1] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][1] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ThirdColumn()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][2] = CreateSquareModelX();
            arg.Squares[1][2] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_ForwardSlant()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void DetectWinner_BackSlant()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][2] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelX();
            arg.Squares[2][0] = CreateSquareModelX();
            var result = _gameWinDetector.DetectWinner(arg);
            Assert.Equal(SquareValue.X, result);
        }

        [Fact]
        public void IsGameDraw_FreshBoard()
        {
            var arg = new GameBoardModel();
            var isDraw = _gameWinDetector.IsGameDraw(arg);
            Assert.False(isDraw);
        }

        [Fact]
        public void IsGameDraw_GameIsDraw()
        {
            var arg = new GameBoardModel();
            arg.Squares[0][0] = CreateSquareModelX();
            arg.Squares[0][1] = CreateSquareModelO();
            arg.Squares[0][2] = CreateSquareModelX();
            
            arg.Squares[1][0] = CreateSquareModelX();
            arg.Squares[1][1] = CreateSquareModelO();
            arg.Squares[1][2] = CreateSquareModelX();
            
            arg.Squares[2][0] = CreateSquareModelO();
            arg.Squares[2][1] = CreateSquareModelX();
            arg.Squares[2][2] = CreateSquareModelO();
            
            var isDraw = _gameWinDetector.IsGameDraw(arg);
            Assert.True(isDraw);
        }

        private static GameBoardSquareModel CreateSquareModelX()
        {
            return new() {CurrentSquareValue = SquareValue.X};
        }

        private static GameBoardSquareModel CreateSquareModelO()
        {
            return new() {CurrentSquareValue = SquareValue.O};
        }
    }
}

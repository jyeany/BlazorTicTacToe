using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Moq;
using Xunit;

namespace BlazorTicTacToeXUnit.Services
{
    //private readonly GameManager _gameManager = new GameManager();

    public class GameManagerTest
    {
        private readonly Mock<IGameWinDetector> _mockGameWinDetector = new();
        private readonly GameManager _gameManager;

        public GameManagerTest()
        {
            _gameManager = new GameManager(_mockGameWinDetector.Object);
        }

        [Fact]
        public void MakeMove_AlreadySet()
        {
            var arg = new GameBoardSquareModel {CurrentSquareValue = SquareValue.O};
            _gameManager.MakeMove(arg);
            Assert.Equal(SquareValue.O, arg.CurrentSquareValue);
        }

        [Fact]
        public void MakeMove_NoWinner()
        {
            var arg = new GameBoardSquareModel {CurrentSquareValue = SquareValue.NotSet};
            _gameManager.PlayerSquareValue = SquareValue.X;
            _mockGameWinDetector
                .Setup(x => x.DetectWinner(_gameManager.CurrentGameBoard))
                .Returns(SquareValue.NotSet);
            _gameManager.MakeMove(arg);
            Assert.Equal(SquareValue.O, _gameManager.PlayerSquareValue);
        }

    }
}

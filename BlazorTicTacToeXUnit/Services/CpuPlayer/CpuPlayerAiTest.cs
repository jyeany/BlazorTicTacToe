using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services.CpuPlayer;
using Xunit;

namespace BlazorTicTacToeXUnit.Services.CpuPlayer
{
    public class CpuPlayerAiTest
    {
        private readonly CpuPlayerAi _cpuPlayerAi = new CpuPlayerAi();
        
        [Fact]
        public void IsFirstMove_NotFirst()
        {
            var gameBoardModel = new GameBoardModel();
            gameBoardModel.Squares[0][0].CurrentSquareValue = SquareValue.X;
            gameBoardModel.Squares[0][1].CurrentSquareValue = SquareValue.O;
            var result = CpuPlayerAi.IsFirstMove(gameBoardModel);
            Assert.False(result);
        }

        [Fact]
        public void IsFirstMove_First()
        {
            var gameBoardModel = new GameBoardModel();
            gameBoardModel.Squares[0][0].CurrentSquareValue = SquareValue.X;
            var result = CpuPlayerAi.IsFirstMove(gameBoardModel);
            Assert.True(result);
        }

        [Fact]
        public void ChooseMove_FirstCenterTaken()
        {
            var gameBoardModel = new GameBoardModel();
            gameBoardModel.Squares[1][1].CurrentSquareValue = SquareValue.X;
            var nextMove = _cpuPlayerAi.ChooseMove(gameBoardModel);
            Assert.Equal(0, nextMove.Column);
            Assert.Equal(0, nextMove.Row);
        }

        [Fact]
        public void ChooseMove_FirstCenterOpen()
        {
            var gameBoardModel = new GameBoardModel();
            gameBoardModel.Squares[2][2].CurrentSquareValue = SquareValue.X;
            var nextMove = _cpuPlayerAi.ChooseMove(gameBoardModel);
            Assert.Equal(1, nextMove.Column);
            Assert.Equal(1, nextMove.Row);            
        }
    }
}
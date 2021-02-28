using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameWinDetector
    {
        SquareValue DetectWinner(GameBoardModel gameBoardModel);
        bool IsGameDraw(GameBoardModel gameBoardModel);
    }
}

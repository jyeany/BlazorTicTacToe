using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services.CpuPlayer
{
    public interface ICpuPlayer
    {
        GameBoardSquareModel ChooseMove(GameBoardModel gameBoard);
    }
}

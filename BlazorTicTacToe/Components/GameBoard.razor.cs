using BlazorTicTacToe.Models;
using BlazorTicTacToe.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToe.Components
{
    public partial class GameBoard
    {
        [Inject]
        protected IGameManage GameManager { get; set; }

        protected GameBoardSquareModel[][] GameBoardSquares()
        {
            return GameManager.CurrentGameBoard.Squares;
        }
    }
}

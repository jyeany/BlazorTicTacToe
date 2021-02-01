using BlazorTicTacToe.Models;
using BlazorTicTacToe.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToe.Components
{
    public partial class GameBoardSquare
    {
        [Parameter]
        public GameBoardSquareModel gameBoardSquareModel { get; set; }

        [Inject]
        protected GameManager GameManager { get; set; }

        public void HandleClick()
        {
            GameManager.MakeMove(this.gameBoardSquareModel);
        }

        public string BtnTypeClass()
        {
            switch (gameBoardSquareModel.CurrentSquareValue)
            {
                case SquareValue.X:
                    return "btn-info";
                case SquareValue.O:
                    return "btn-danger";
                default:
                    return "btn-secondary";
            }
        }
    }
}

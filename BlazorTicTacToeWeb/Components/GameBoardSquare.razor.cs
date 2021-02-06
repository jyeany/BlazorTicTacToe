using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToeWeb.Components
{
    public partial class GameBoardSquare
    {
        [Parameter]
        public GameBoardSquareModel GameBoardSquareModel { get; set; }

        [Inject]
        protected IGameManager GameManager { get; set; }

        public void HandleClick()
        {
            GameManager.MakeMove(this.GameBoardSquareModel);
        }

        public string BtnTypeClass()
        {
            switch (GameBoardSquareModel.CurrentSquareValue)
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

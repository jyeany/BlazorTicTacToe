using System;
using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToeWeb.Components
{
    public partial class GameBoardSquare : IGameWinObserver
    {
        [Parameter]
        public GameBoardSquareModel GameBoardSquareModel { get; set; }

        [Inject]
        private IGameManager GameManager { get; set; }

        protected override void OnInitialized()
        {
            GameManager.TurnChangeEvent += OnTurnChangeEvent;
        }

        private void HandleClick()
        {
            GameManager.MakeMove(GameBoardSquareModel);
        }

        private string BtnTypeClass()
        {
            return GameBoardSquareModel.CurrentSquareValue switch
            {
                SquareValue.X => "btn-info",
                SquareValue.O => "btn-danger",
                _ => "btn-secondary"
            };
        }

        public void GameWonBy(SquareValue squareValue)
        {
            StateHasChanged();
        }

        private void OnTurnChangeEvent(object sender, SquareValueEventArgs e)
        {
            StateHasChanged();
        }
    }
}

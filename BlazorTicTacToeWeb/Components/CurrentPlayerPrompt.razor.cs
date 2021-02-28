using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTicTacToeWeb.Components
{
    public partial class CurrentPlayerPrompt
    {
        [Inject] 
        private IGameManager GameManager { get; set; }

        private SquareValue CurrentSquareValue { get; set; }

        protected override void OnInitialized()
        {
            CurrentSquareValue = GameManager.PlayerSquareValue;
        }

        private void OnTurnChangeEvent(object sender, SquareValueEventArgs e)
        {
            CurrentSquareValue = e.SquareValue;
            StateHasChanged();
        }
    }
}

﻿using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToeWeb.Pages
{
    public partial class TicTacToe
    {
        [Inject]
        protected IGameManager GameManager { get; set; }

        private void StartGame(GameType gameType)
        {
            GameManager.StartGame(gameType);
        }

                
    }
}

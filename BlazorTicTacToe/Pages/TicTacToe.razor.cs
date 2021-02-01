using BlazorTicTacToe.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Pages
{
    public partial class TicTacToe
    {
        [Inject]
        protected GameManager GameManager { get; set; }

        private void StartGame(GameType gameType)
        {
            GameManager.StartGame(gameType);
        }

                
    }
}

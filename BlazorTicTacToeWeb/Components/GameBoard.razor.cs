using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorTicTacToeWeb.Components
{
    public partial class GameBoard
    {
        [Inject]
        private IGameManager GameManager { get; set; }

        private SquareValue CurrentPlayerSquareValue { get; set; }
        
        private SquareValue GameWinner { get; set; }

        protected override void OnInitialized()
        {            
            CurrentPlayerSquareValue = GameManager.PlayerSquareValue;
            GameWinner = SquareValue.NotSet;
            GameManager.GameWinEvent += OnGameWon;
        }        

        private GameBoardSquareModel[][] GameBoardSquares()
        {
            return GameManager.CurrentGameBoard.Squares;
        }

        private void OnGameWon(object sender, SquareValueEventArgs e)
        {
            GameWinner = e.SquareValue;
            StateHasChanged();
        }
    }
}

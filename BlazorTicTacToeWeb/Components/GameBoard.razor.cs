using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorTicTacToeWeb.Components
{
    public partial class GameBoard: IGameWinObserver
    {
        [Inject]
        protected IGameManager GameManager { get; set; }

        protected SquareValue CurrentPlayerSquareValue { get; set; }
        
        protected SquareValue GameWinner { get; set; }

        protected override void OnInitialized()
        {            
            CurrentPlayerSquareValue = GameManager.PlayerSquareValue;
            GameWinner = SquareValue.NotSet;
            GameManager.GameWinSubscribe(this);
        }        

        protected GameBoardSquareModel[][] GameBoardSquares()
        {
            return GameManager.CurrentGameBoard.Squares;
        }

        public void GameWonBy(SquareValue squareValue)
        {
            GameWinner = squareValue;
            StateHasChanged();
        }
    }
}

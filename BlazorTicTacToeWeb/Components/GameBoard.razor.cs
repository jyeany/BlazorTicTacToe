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
        protected GameManager GameManager { get; set; }

        protected SquareValue CurrentPlayerSquareValue { get; set; }        

        protected override void OnInitialized()
        {            
            CurrentPlayerSquareValue = GameManager.PlayerSquareValue;
        }        

        protected GameBoardSquareModel[][] GameBoardSquares()
        {
            return GameManager.CurrentGameBoard.Squares;
        }
    }
}

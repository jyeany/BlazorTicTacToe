using System;
using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTicTacToeWeb.Components
{
    public partial class GameBoardSquare : IObserver<SquareValue>, IGameWinObserver
    {
        [Parameter]
        public GameBoardSquareModel GameBoardSquareModel { get; set; }

        [Inject]
        protected IGameManager GameManager { get; set; }

        protected override void OnInitialized()
        {
            GameManager.Subscribe(this);
        }

        public void HandleClick()
        {
            GameManager.MakeMove(GameBoardSquareModel);
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

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(SquareValue value)
        {
            StateHasChanged();
        }

        public void GameWonBy(SquareValue squareValue)
        {
            StateHasChanged();
        }
    }
}

using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorTicTacToeWeb.Components
{
    public partial class CurrentPlayerPrompt: IObserver<SquareValue>
    {
        [Inject]
        protected IGameManager GameManager { get; set; }

        public SquareValue CurrentSquareValue { get; set; }

        protected override void OnInitialized()
        {
            GameManager.Subscribe(this);
            CurrentSquareValue = GameManager.PlayerSquareValue;
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
            this.CurrentSquareValue = value;
            StateHasChanged();
        }
    }
}

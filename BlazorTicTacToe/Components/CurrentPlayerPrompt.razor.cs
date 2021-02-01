using BlazorTicTacToe.Models;
using BlazorTicTacToe.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Components
{
    public partial class CurrentPlayerPrompt: IObserver<SquareValue>
    {
        [Inject]
        protected GameManager GameManager { get; set; }

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

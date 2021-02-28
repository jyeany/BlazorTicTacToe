using BlazorTicTacToeWeb.Models;
using System;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameManager : IGameWinObservable
    {
        public SquareValue PlayerSquareValue { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }

        public GameType CurrentGameType { get; set; }

        void StartGame(GameType gameType);

        void MakeMove(GameBoardSquareModel squareModel);

        public SquareValue GameWinner { get; set; }

        public event EventHandler<SquareValueEventArgs> TurnChangeEvent;
    }
}

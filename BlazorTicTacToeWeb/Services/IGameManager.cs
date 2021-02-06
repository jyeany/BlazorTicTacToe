using BlazorTicTacToeWeb.Models;
using System;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameManager : IObservable<SquareValue>, IGameWinObservable
    {
        public SquareValue PlayerSquareValue { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }

        public GameType CurrentGameType { get; set; }

        void StartGame(GameType gameType);

        void MakeMove(GameBoardSquareModel squareModel);

    }
}

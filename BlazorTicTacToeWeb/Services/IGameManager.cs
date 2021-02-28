using BlazorTicTacToeWeb.Models;
using System;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameManager
    {
        public SquareValue PlayerSquareValue { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }

        public GameType CurrentGameType { get; set; }

        void StartGame(GameType gameType);

        void MakeMove(GameBoardSquareModel squareModel);

        public SquareValue GameWinner { get; set; }

        public bool IsGameDraw { get; set; }
        public event EventHandler<SquareValueEventArgs> TurnChangeEvent;

        public event EventHandler<SquareValueEventArgs> GameWinEvent;
    }
}

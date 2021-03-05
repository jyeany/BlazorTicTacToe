using System;
using BlazorTicTacToeWeb.Models;
using BlazorTicTacToeWeb.Services.CpuPlayer;

namespace BlazorTicTacToeWeb.Services
{
    public enum GameType { NotChosen = 0, OnePlayer, TwoPlayer };

    public class GameManager : IGameManager
    {
        private readonly IGameWinDetector _gameWinDetector;

        public GameType CurrentGameType { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }
        
        public SquareValue PlayerSquareValue { get; set; }

        public SquareValue GameWinner { get; set; }
        
        public bool IsGameDraw { get; set; }

        public event EventHandler<SquareValueEventArgs> TurnChangeEvent;
        public event EventHandler<SquareValueEventArgs> GameWinEvent;

        private ICpuPlayer _cpuPlayer;

        public const int NumRowsCols = 3;

        public GameManager(IGameWinDetector gameWinDetector)
        {
            this._gameWinDetector = gameWinDetector;
        }

        public void StartGame(GameType gameType)
        {
            CurrentGameType = gameType;
            PlayerSquareValue = SquareValue.X; // x always goes first
            CurrentGameBoard = new GameBoardModel();
            IsGameDraw = false;
            if (CurrentGameType == GameType.OnePlayer)
            {
                _cpuPlayer = new CpuPlayerRandom();
            }
        }

        public void MakeMove(GameBoardSquareModel squareModel)
        {
            while (true)
            {
                if (squareModel.CurrentSquareValue == SquareValue.NotSet)
                {
                    squareModel.CurrentSquareValue = PlayerSquareValue;
                    var winnerValue = _gameWinDetector.DetectWinner(CurrentGameBoard);
                    IsGameDraw = _gameWinDetector.IsGameDraw(CurrentGameBoard);
                    if (winnerValue == SquareValue.NotSet && !IsGameDraw)
                    {
                        SwitchPlayer();
                        if (CurrentGameType == GameType.OnePlayer && PlayerSquareValue == SquareValue.O)
                        {
                            var move = _cpuPlayer.ChooseMove(CurrentGameBoard);
                            squareModel = move;
                            continue;
                        }
                    }
                    else
                    {
                        GameWinner = winnerValue;
                        var gameWonArgs = new SquareValueEventArgs() {SquareValue = winnerValue};
                        OnGameWon(gameWonArgs);
                    }
                }
                break;
            }
        }

        private void OnTurnChanged(SquareValueEventArgs e)
        {
            var handler = TurnChangeEvent;
            handler?.Invoke(this, e);
        }

        private void OnGameWon(SquareValueEventArgs e)
        {
            var handler = GameWinEvent;
            handler?.Invoke(this, e);
        }
        
        private void SwitchPlayer()
        {
            PlayerSquareValue = PlayerSquareValue == SquareValue.X ? SquareValue.O : SquareValue.X;
            var eventArgs = new SquareValueEventArgs() {SquareValue = PlayerSquareValue};
            OnTurnChanged(eventArgs);
        }

    }
}

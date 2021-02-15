using BlazorTicTacToeWeb.Models;
using System;
using System.Collections.Generic;
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

        private readonly List<IGameWinObserver> _gameWinObservers = new();

        private readonly List<IObserver<SquareValue>> _turnChangeObservers = new();

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
                    if (winnerValue == SquareValue.NotSet)
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
                        NotifySubscribersOfWin();
                    }
                }

                break;
            }
        }

        public IDisposable Subscribe(IObserver<SquareValue> observer)
        {
            if (!_turnChangeObservers.Contains(observer))
            {
                _turnChangeObservers.Add(observer);
            }
            return new Unsubscriber<SquareValue>(_turnChangeObservers, observer);
        }

        public void GameWinSubscribe(IGameWinObserver observer)
        {
            this._gameWinObservers.Add(observer);
        }

        public void GameWinUnsubscribe(IGameWinObserver observer)
        {
            this._gameWinObservers.Remove(observer);
        }

        public void NotifySubscribersOfWin()
        {
            foreach (var observer in _gameWinObservers)
            {
                observer.GameWonBy(GameWinner);
            }
        }

        private void SwitchPlayer()
        {
            PlayerSquareValue = PlayerSquareValue == SquareValue.X ? SquareValue.O : SquareValue.X;
            NotifyTurnChangeObservers(PlayerSquareValue);
        }

        private void NotifyTurnChangeObservers(SquareValue value)
        {
            foreach (var sqValObserver in _turnChangeObservers)
            {
                sqValObserver.OnNext(value);
            }
        }

        internal class Unsubscriber<TSquareInfo> : IDisposable
        {
            private readonly List<IObserver<TSquareInfo>> _observers;
            private readonly IObserver<TSquareInfo> _observer;

            internal Unsubscriber(List<IObserver<TSquareInfo>> observers, IObserver<TSquareInfo> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

    }
}

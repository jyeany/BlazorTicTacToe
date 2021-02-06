using BlazorTicTacToeWeb.Models;
using System;
using System.Collections.Generic;

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

        public const int NumRowsCols = 3;

        public GameManager(IGameWinDetector gameWinDetector)
        {
            this._gameWinDetector = gameWinDetector;
        }

        public void StartGame(GameType gameType)
        {
            CurrentGameType = gameType;
            PlayerSquareValue = SquareValue.X; // x always goes first
            InitializeBoard();
        }

        public void MakeMove(GameBoardSquareModel squareModel)
        {
            if (squareModel.CurrentSquareValue == SquareValue.NotSet)
            {
                squareModel.CurrentSquareValue = PlayerSquareValue;
                SquareValue winnerValue = _gameWinDetector.DetectWinner(CurrentGameBoard);
                if (winnerValue == SquareValue.NotSet)
                {
                    SwitchPlayer();
                    NotifyTurnChangeObservers(PlayerSquareValue);
                }
                else
                {
                    GameWinner = winnerValue;
                    NotifySubscribersOfWin();
                }
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
        }

        private void NotifyTurnChangeObservers(SquareValue value)
        {
            foreach (var sqValObserver in _turnChangeObservers)
            {
                sqValObserver.OnNext(value);
            }
        }

        private void InitializeBoard()
        {
            var gameBoard = new GameBoardModel();
            var squares = gameBoard.Squares;
            for (var i = 0; i < NumRowsCols; i++)
            {
                for (var j = 0; j < NumRowsCols; j++)
                {
                    var toAdd = new GameBoardSquareModel
                    {
                        Row = i,
                        Column = j,
                        CurrentSquareValue = SquareValue.NotSet
                    };
                    squares[i][j] = toAdd;
                }
            }
            CurrentGameBoard = gameBoard;
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

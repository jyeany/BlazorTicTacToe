using BlazorTicTacToeWeb.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorTicTacToeWeb.Services
{
    public enum GameType { NotChosen = 0, OnePlayer, TwoPlayer };

    public class GameManager : IObservable<SquareValue>, IGameWinObservable
    {
        private readonly GameWinDetector gameWinDetector;

        public GameType CurrentGameType { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }

        public SquareValue PlayerSquareValue { get; set; }

        public SquareValue GameWinner { get; set; }

        private List<IGameWinObserver> gameWinObservers = new List<IGameWinObserver>();

        private List<IObserver<SquareValue>> turnChangeObservers = 
            new List<IObserver<SquareValue>>();

        public const int NUM_ROWS_COLS = 3;

        public GameManager(GameWinDetector gameWinDetector)
        {
            this.gameWinDetector = gameWinDetector;
        }

        public void StartGame(GameType gameType)
        {
            CurrentGameType = gameType;
            PlayerSquareValue = SquareValue.X; // x always goes first
            initializeBoard();
        }

        public void MakeMove(GameBoardSquareModel squareModel)
        {
            if (squareModel.CurrentSquareValue == SquareValue.NotSet)
            {
                squareModel.CurrentSquareValue = PlayerSquareValue;
                SquareValue winnerValue = gameWinDetector.DetectWinner(CurrentGameBoard);
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
            if (!turnChangeObservers.Contains(observer))
            {
                turnChangeObservers.Add(observer);
            }
            return new Unsubscriber<SquareValue>(turnChangeObservers, observer);
        }

        private void SwitchPlayer()
        {
            if (PlayerSquareValue == SquareValue.X)
            {
                PlayerSquareValue = SquareValue.O;
            }
            else
            {
                PlayerSquareValue = SquareValue.X;
            }            
        }

        private void NotifyTurnChangeObservers(SquareValue value)
        {
            foreach (var sqValObserver in turnChangeObservers)
            {
                sqValObserver.OnNext(value);
            }
        }

        private void initializeBoard()
        {
            GameBoardModel gameBoard = new GameBoardModel();
            GameBoardSquareModel[][] squares = gameBoard.Squares;
            for (int i = 0; i < NUM_ROWS_COLS; i++)
            {
                for (int j = 0; j < NUM_ROWS_COLS; j++)
                {
                    GameBoardSquareModel toAdd = new GameBoardSquareModel();
                    toAdd.Row = i;
                    toAdd.Column = j;
                    toAdd.CurrentSquareValue = SquareValue.NotSet;
                    squares[i][j] = toAdd;
                }
            }
            this.CurrentGameBoard = gameBoard;
        }

        public void GameWinSubscribe(IGameWinObserver observer)
        {
            this.gameWinObservers.Add(observer);
        }

        public void GameWinUnsubscribe(IGameWinObserver observer)
        {
            this.gameWinObservers.Remove(observer);
        }

        public void NotifySubscribersOfWin()
        {
            foreach (var observer in gameWinObservers)
            {
                observer.GameWonBy(GameWinner);
            }
        }

        internal class Unsubscriber<SquareInfo> : IDisposable
        {
            private List<IObserver<SquareInfo>> _observers;
            private IObserver<SquareInfo> _observer;

            internal Unsubscriber(List<IObserver<SquareInfo>> observers, IObserver<SquareInfo> observer)
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

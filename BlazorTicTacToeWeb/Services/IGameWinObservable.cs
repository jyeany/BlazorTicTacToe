using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameWinObservable
    {
        void GameWinSubscribe(IGameWinObserver observer);

        void GameWinUnsubscribe(IGameWinObserver observer);

        void NotifySubscribersOfWin();
    }
}

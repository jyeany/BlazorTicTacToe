using BlazorTicTacToeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToeWeb.Services
{
    public interface IGameWinObserver
    {
        void GameWonBy(SquareValue squareValue);
    }
}

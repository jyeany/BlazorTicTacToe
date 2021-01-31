using BlazorTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Services
{

    public enum GameType { NotChosen = 0, OnePlayer, TwoPlayer }

    public interface IGameManage
    {
        GameType CurrentGameType { get; set; }

        GameBoardModel CurrentGameBoard { get; set; }

        void StartGame(GameType gameType);
    }
}

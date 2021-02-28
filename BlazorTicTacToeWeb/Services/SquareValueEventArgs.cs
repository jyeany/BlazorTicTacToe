using System;
using BlazorTicTacToeWeb.Models;

namespace BlazorTicTacToeWeb.Services
{
    public class SquareValueEventArgs : EventArgs
    {
        public SquareValue SquareValue { get; init; }
    }
}
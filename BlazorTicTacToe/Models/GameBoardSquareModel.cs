using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Models
{
    public enum SquareValue { NotSet = 0, X, O }

    public class GameBoardSquareModel
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public SquareValue CurrentSquareValue { get; set; }
    }
}

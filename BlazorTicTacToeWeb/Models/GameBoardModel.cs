using BlazorTicTacToeWeb.Services;

namespace BlazorTicTacToeWeb.Models
{
    public class GameBoardModel
    {
        public GameBoardSquareModel[][] Squares { get; }
        private readonly GameBoardSquareModel[][] _squares = 
            new GameBoardSquareModel[GameManager.NumRowsCols][]
            {
                new GameBoardSquareModel[GameManager.NumRowsCols],
                new GameBoardSquareModel[GameManager.NumRowsCols],
                new GameBoardSquareModel[GameManager.NumRowsCols]
            };
        
        public GameBoardModel()
        {
            Squares = _squares;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (var i = 0; i < GameManager.NumRowsCols; i++)
            {
                for (var j = 0; j < GameManager.NumRowsCols; j++)
                {
                    var toAdd = new GameBoardSquareModel
                    {
                        Row = i,
                        Column = j,
                        CurrentSquareValue = SquareValue.NotSet
                    };
                    _squares[i][j] = toAdd;
                }
            }
        }
    }
}

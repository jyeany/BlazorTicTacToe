using BlazorTicTacToeWeb.Services;

namespace BlazorTicTacToeWeb.Models
{
    public class GameBoardModel
    {
        public GameBoardSquareModel[][] Squares { get; }
        private GameBoardSquareModel[][] _squares = 
            new GameBoardSquareModel[GameManager.NumRowsCols][]
            {
                new GameBoardSquareModel[GameManager.NumRowsCols],
                new GameBoardSquareModel[GameManager.NumRowsCols],
                new GameBoardSquareModel[GameManager.NumRowsCols]
            };
        
        public GameBoardModel()
        {
            this.Squares = _squares;
        }
    }
}

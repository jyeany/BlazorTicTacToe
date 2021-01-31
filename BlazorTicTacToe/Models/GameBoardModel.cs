using BlazorTicTacToe.Services;

namespace BlazorTicTacToe.Models
{
    public class GameBoardModel
    {
        public GameBoardSquareModel[][] Squares { get; }
        private GameBoardSquareModel[][] squares = 
            new GameBoardSquareModel[GameManager.NUM_ROWS_COLS][]
            {
                new GameBoardSquareModel[GameManager.NUM_ROWS_COLS],
                new GameBoardSquareModel[GameManager.NUM_ROWS_COLS],
                new GameBoardSquareModel[GameManager.NUM_ROWS_COLS]
            };
        
        public GameBoardModel()
        {
            this.Squares = squares;
        }
    }
}

using BlazorTicTacToe.Models;

namespace BlazorTicTacToe.Services
{
    public class GameManager : IGameManage
    {
        public GameType CurrentGameType { get; set; }

        public GameBoardModel CurrentGameBoard { get; set; }

        public const int NUM_ROWS_COLS = 3;

        public void StartGame(GameType gameType)
        {
            this.CurrentGameType = gameType;
            initializeBoard();
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
    }
}

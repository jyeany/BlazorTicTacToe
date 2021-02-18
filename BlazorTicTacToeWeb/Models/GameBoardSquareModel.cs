namespace BlazorTicTacToeWeb.Models
{
    public enum SquareValue { NotSet = 0, X, O }

    public class GameBoardSquareModel
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public SquareValue CurrentSquareValue { get; set; }

        public override string ToString() =>
            CurrentSquareValue switch
            {
                SquareValue.X => "X",
                SquareValue.O => "O",
                _ => "--"
            };
    }
}

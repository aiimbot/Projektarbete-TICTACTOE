public abstract class Ruleset
{
    public abstract List<int> ListValidMoves(Board board);

    public void Place(Board board, int move, Mark mark)
    {
        board.Place(move, mark);
    }

    public bool IsWinner(Board board, Mark mark)
    {
        return board.HasWinLine(mark);
    }

    public bool IsDraw(Board board)
    {
        return board.IsFull();
    }
}
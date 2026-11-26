public class ClassicRuleset
{
    public virtual List<int> ListValidMoves(Board board)
    {
        return board.ListFreePositions();
    }

    public virtual void Place(Board board, int move, Mark mark)
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
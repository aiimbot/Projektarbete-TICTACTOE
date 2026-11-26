public class Ruleset
{
    private readonly int lineLength;

    public Ruleset(int lineLength)
    {
        this.lineLength = lineLength;
    }

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
        return board.HasLine(mark, lineLength);
    }

    public bool IsDraw(Board board)
    {
        return board.IsFull();
    }
}
public class Ruleset
{
    private readonly int lineLength;

    public Ruleset(int lineLength)
    {
        this.lineLength = lineLength;
    }

    // Arv: standardregel, subtyperna kan överskrida virtual,
    //  här är giltiga drag är alla lediga rutor
    public virtual List<int> ListValidMoves(Board board)
    {
        return board.ListFreePositions();
    }

    // Arv: standardplacering, subtyperna kan överskrida virtual,
    // här läggs märket i vald ruta
    public virtual void Place(Board board, int move, Mark mark)
    {
        board.Place(move, mark);
    }

    // Arv: ärvs oförändrad av alla regelset.
    public bool IsWinner(Board board, Mark mark)
    {
        return board.HasLine(mark, lineLength);
    }

    // Arv: ärvs oförändrad av alla regelset
    public bool IsDraw(Board board)
    {
        return board.IsFull();
    }
}
public class VanishingRuleset : Ruleset
{
    private readonly int maxMarks;
    
    public VanishingRuleset(int lineLength, int maxMarks) : base(lineLength)
    {
        this.maxMarks = maxMarks;
    }

    public override void Place(Board board, int move, Mark mark)
    {
        board.Place(move, mark);
        if (board.CountMarks(mark) > maxMarks)
        {
            board.RemoveOldest(mark);
        }
    }
}
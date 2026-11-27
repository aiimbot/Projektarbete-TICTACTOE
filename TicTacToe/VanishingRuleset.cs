// Arv: ärver ListValidMoves, IsWinner och IsDraw från Ruleset
public class VanishingRuleset : Ruleset
{
    private readonly int maxMarks;

    public VanishingRuleset(int lineLength, int maxMarks) : base(lineLength)
    {
        this.maxMarks = maxMarks;
    }

    // Arv: skriver över, äldsta märket försvinner vid för många
    public override void Place(Board board, int move, Mark mark)
    {
        board.Place(move, mark);
        if (board.CountMarks(mark) > maxMarks)
        {
            board.RemoveOldest(mark);
        }
    }
}
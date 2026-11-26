public class GravityRuleset : Ruleset
{
    public GravityRuleset(int lineLength) : base(lineLength)
    {
    }

    public override List<int> ListValidMoves(Board board)
    {
        return board.ListFreeColumns();
    }

    public override void Place(Board board, int move, Mark mark)
    {
        board.Place(board.FindLowestFree(move), mark);
    }
}
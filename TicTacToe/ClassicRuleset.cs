public class ClassicRuleset : Ruleset
{
    public override List<int> ListValidMoves(Board board)
    {
        return board.ListFreePositions();
    }
}
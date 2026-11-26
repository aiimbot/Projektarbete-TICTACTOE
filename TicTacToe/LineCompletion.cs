public class LineCompletion : IStrategy
{
    private readonly Ruleset rules;
    private readonly Mark mark;

    public LineCompletion(Ruleset rules, Mark mark)
    {
        this.rules = rules;
        this.mark = mark;
    }

    public int? FindMove(Board board, List<int> validMoves)
    {
        foreach (int move in validMoves)
        {
            Board copy = board.Copy();
            rules.Place(copy, move, mark);

            if (rules.IsWinner(copy, mark))
            {
                return move;
            }
        }

        return null;
    }
}
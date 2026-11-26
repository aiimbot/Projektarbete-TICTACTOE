public class PreferredCells : IStrategy
{
    private readonly int[] cells;

    public PreferredCells(int[] cells)
    {
        this.cells = cells;
    }

    public int? FindMove(Board board, List<int> validMoves)
    {
        foreach (int cell in cells)
        {
            if (validMoves.Contains(cell))
            {
                return cell;
            }
        }

        return null;
    }
}
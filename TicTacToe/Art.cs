public class Art
{
    private readonly string[] x =
    {
        @"         ",
        @"  \   /  ",
        @"   \ /   ",
        @"    X    ",
        @"   / \   ",
        @"  /   \  ",
        @"         "
    };

    private readonly string[] o =
    {
        @"         ",
        @"   ---   ",
        @"  /   \  ",
        @"  |   |  ",
        @"  \   /  ",
        @"   ---   ",
        @"         "
    };

    private readonly string[] empty =
    {
        @"         ",
        @"         ",
        @"         ",
        @"         ",
        @"         ",
        @"         ",
        @"         "
    };

    private readonly Dictionary<Mark, string[]> rows;

    public Art()
    {
        rows = new Dictionary<Mark, string[]>
        {
            [Mark.X] = x,
            [Mark.O] = o,
            [Mark.Empty] = empty
        };
    }

    public string ReadRow(Mark mark, int row)
    {
    	return rows[mark][row];
    }

    public int CountRows()
    {
    	return rows[Mark.Empty].Length;
    }

    public string DrawBorder(int columns)
    {
        return "+" + string.Concat(Enumerable.Repeat("---------+", columns));
    }
}
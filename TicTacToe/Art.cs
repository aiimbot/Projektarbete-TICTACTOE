public class Art
{
    private readonly string[] X =
    {
        @"         ",
        @"  \   /  ",
        @"   \ /   ",
        @"    X    ",
        @"   / \   ",
        @"  /   \  ",
        @"         "
    };

    private readonly string[] O =
    {
        @"         ",
        @"   ---   ",
        @"  /   \  ",
        @"  |   |  ",
        @"  \   /  ",
        @"   ---   ",
        @"         "
    };

    private readonly string[] Empty =
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
            [Mark.X] = X,
            [Mark.O] = O,
            [Mark.Empty] = Empty
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
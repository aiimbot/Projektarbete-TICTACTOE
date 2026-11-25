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

    private readonly string[] Null =
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
            [Mark.Null] = Null
        };
    }

    public string ReadRow(Mark mark, int row)
    {
    	return rows[mark][row];
    }

    public int CountRows()
    {
    	return rows[Mark.Null].Length;
    }

    public string DrawBorder()
    {
    	return "+---------+---------+---------+";
    }
}
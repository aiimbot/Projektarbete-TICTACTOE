public class Art
{
    private const string Reset = "\u001b[0m";

    private readonly string[] x =
    {
        " ██   ██ ",
        "  ██ ██  ",
        "   ███   ",
        "  ██ ██  ",
        " ██   ██ "
    };

    private readonly string[] o =
    {
        "  █████  ",
        " ██   ██ ",
        " ██   ██ ",
        " ██   ██ ",
        "  █████  "
    };

    private readonly string[] empty =
    {
        "         ",
        "         ",
        "         ",
        "         ",
        "         "
    };

    private readonly string[] top = { "┌", "┬", "┐" };
    private readonly string[] middle = { "├", "┼", "┤" };
    private readonly string[] bottom = { "└", "┴", "┘" };

    private readonly Dictionary<Mark, string[]> rows;
    private readonly Dictionary<Mark, string> colors;

    public Art()
    {
        rows = new Dictionary<Mark, string[]>
        {
            [Mark.X] = x,
            [Mark.O] = o,
            [Mark.Empty] = empty
        };
        colors = new Dictionary<Mark, string>
        {
            [Mark.X] = "\u001b[91m",
            [Mark.O] = "\u001b[94m",
            [Mark.Empty] = "\u001b[90m"
        };
    }

    public string ReadRow(Mark mark, int row, int position)
    {
        string[] art = rows[mark];
        string text = art[row];

        if (mark == Mark.Empty && row == art.Length / 2)
        {
            string label = (position + 1).ToString();
            text = label.PadLeft((text.Length + label.Length) / 2)
                .PadRight(text.Length);
        }

        return colors[mark] + text + Reset;
    }

    public int CountRows()
    {
        return rows[Mark.Empty].Length;
    }

    public string DrawBorder(int columns, int row)
    {
        string[] corners = row == 0 ? top : row == columns ? bottom : middle;
        string line = new string('─', rows[Mark.Empty][0].Length);
        return corners[0]
            + string.Join(corners[1], Enumerable.Repeat(line, columns))
            + corners[2];
    }
}
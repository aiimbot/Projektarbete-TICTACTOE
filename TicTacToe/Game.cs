public class Game
{
    private readonly Board board;
    private readonly Ruleset rules;
    private readonly Display display;
    private readonly TurnOrder turnorder;

    public Game(Board board, Ruleset rules, Display display,
        TurnOrder turnorder)
    {
        this.board = board;
        this.rules = rules;
        this.display = display;
        this.turnorder = turnorder;
    }

    public void Play()
    {
        Mark mark;

        do
        {
            display.DrawBoard(board);
            mark = turnorder.PlayTurn(board, rules);
        }
        while (!rules.IsWinner(board, mark) && !rules.IsDraw(board));

        display.DrawBoard(board);
        display.ShowResult(rules.IsWinner(board, mark), mark);
    }
}
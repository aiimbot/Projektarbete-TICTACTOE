public class Game
{
    private readonly Board board;
    private readonly Ruleset rules;
    private readonly Display display;
    private readonly TurnOrder turnorder;

    // Beroendeinjektion: regelset och spelare injiceras, så nya lägen
    // och motståndare kan läggas till utan att ändra Game
    public Game(Board board, Ruleset rules, Display display,
        TurnOrder turnorder)
    {
        this.board = board;
        this.rules = rules;
        this.display = display;
        this.turnorder = turnorder;
    }

    // Subtypspolymorfism: Game vet om att den har en TurnOrder
    // men inte vad TurnOrdern är
    // TurnOrdern har i sin tur två IPlayer
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
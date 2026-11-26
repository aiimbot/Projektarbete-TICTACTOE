public class Game
{
    private readonly Board board;
    private readonly Ruleset rules;
    private readonly Display display;
    private readonly IPlayer[] players;
    private readonly Mark[] marks;

    public Game(Board board, Ruleset rules, Display display, IPlayer[] players, Mark[] marks)
    {
        this.board = board;
        this.rules = rules;
        this.display = display;
        this.players = players;
        this.marks = marks;
    }
    public void Play()
    {
        int turn = 0;
        Mark mark;

        do
        {
            display.DrawBoard(board);
            mark = marks[turn % 2];
            List<int> moves = rules.ListValidMoves(board);
            int move = players[turn % 2].ChooseMove(board, moves);
            rules.Place(board, move, mark);
            turn++;
        }
        while (!rules.IsWinner(board, mark) && !rules.IsDraw(board));

        display.DrawBoard(board);
        display.ShowResult(rules.IsWinner(board, mark), mark);
    }
}
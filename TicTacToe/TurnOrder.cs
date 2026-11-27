public class TurnOrder
{
    private readonly IPlayer[] players;
    private readonly Mark[] marks;
    private int turn;

    public TurnOrder(IPlayer[] players, Mark[] marks, Random random)
    {
        this.players = players;
        this.marks = marks;
        turn = random.Next(players.Length);
    }

    public Mark PlayTurn(Board board, Ruleset rules)
    {
        Mark mark = marks[turn % marks.Length];
        List<int> moves = rules.ListValidMoves(board);
        int move = players[turn % players.Length].ChooseMove(board, moves);
        rules.Place(board, move, mark);
        turn++;
        return mark;
    }
}
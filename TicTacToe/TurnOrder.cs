public class TurnOrder
{
    private readonly IPlayer[] players;
    private readonly Mark[] marks;
    private int turn;

    // Beroendeinjektion: spelarna injiceras, valfri kombination
    // av människa och dator
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
        // Subtypspolymorfism: vet inte om det är människa eller dator
        int move = players[turn % players.Length].ChooseMove(board, moves);
        // Arv: Place körs i det regelset som skickades in
        rules.Place(board, move, mark);
        turn++;
        return mark;
    }
}
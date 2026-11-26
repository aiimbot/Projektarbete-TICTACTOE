public class ThinkingPlayer : IPlayer
{
    private readonly IPlayer player;
    private readonly int delay;

    public ThinkingPlayer(IPlayer player, int delay)
    {
        this.player = player;
        this.delay = delay;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        Console.Write("Datorn tänker");

        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(delay / 3);
            Console.Write(".");
        }

        Console.WriteLine();
        return player.ChooseMove(board, validMoves);
    }
}
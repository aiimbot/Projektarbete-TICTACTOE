public class ThinkingPlayer : IPlayer
{
    private readonly IPlayer player;
    public ThinkingPlayer(IPlayer player)
    {
        this.player = player;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        Console.Write("Datorn tänker");

        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1500 / 3);
            Console.Write(".");
        }

        Console.WriteLine();
        return player.ChooseMove(board, validMoves);
    }
}
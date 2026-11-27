public class ThinkingPlayer : IPlayer
{
    private readonly IPlayer player;
    private const int Dots = 3;
    private const int PauseMilliseconds = 500;

    public ThinkingPlayer(IPlayer player)
    {
        this.player = player;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        Console.Write("Datorn tänker");

        for (int i = 0; i < Dots; i++)
        {
            Thread.Sleep(PauseMilliseconds);
            Console.Write(".");
        }

        Console.WriteLine();
        return player.ChooseMove(board, validMoves);
    }
}
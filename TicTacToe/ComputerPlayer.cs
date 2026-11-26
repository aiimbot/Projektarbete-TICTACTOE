public class ComputerPlayer : IPlayer
{
    private readonly IStrategy[] strategies;

    public ComputerPlayer(IStrategy[] strategies)
    {
        this.strategies = strategies;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        foreach (IStrategy strategy in strategies)
        {
            int? move = strategy.FindMove(board, validMoves);

            if (move != null)
            {
                return move.Value;
            }
        }

        throw new InvalidOperationException("Ingen strategi hittade drag.");
    }
}
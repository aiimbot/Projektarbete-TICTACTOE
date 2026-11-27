public class ComputerPlayer : IPlayer
{
    private readonly IStrategy[] strategies;

    // Beroendeinjektion: strategierna injiceras, en annan lista ger
    // en annan svårighetsgrad utan ny klass
    public ComputerPlayer(IStrategy[] strategies)
    {
        this.strategies = strategies;
    }

    // Subtypspolymorfism: provar strategierna i ordning tills en ger drag
    public int ChooseMove(Board board, List<int> validMoves)
    {
        foreach (IStrategy strategy in strategies)
        {
            // Subtypspolymorfism: varje strategi letar drag på sitt sätt
            int? move = strategy.FindMove(board, validMoves);

            if (move != null)
            {
                return move.Value;
            }
        }

        throw new InvalidOperationException("Ingen strategi hittade drag.");
    }
}
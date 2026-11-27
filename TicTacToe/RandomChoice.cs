public class RandomChoice : IStrategy
{
    private readonly Random random;
    public RandomChoice(Random random)
    {
        this.random = random;
    }

    // Subtypspolymorfism: slumpar ett av de giltiga dragen
    public int? FindMove(Board board, List<int> validMoves)
    {
        return validMoves[random.Next(validMoves.Count)];
    }
}
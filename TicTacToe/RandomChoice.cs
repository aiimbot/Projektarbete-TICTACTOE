public class RandomChoice : IStrategy
{
    private readonly Random random;

    // Subtypspolymorfism: slumpar ett av de giltiga dragen
    public RandomChoice(Random random)
    {
        this.random = random;
    }

    public int? FindMove(Board board, List<int> validMoves)
    {
        return validMoves[random.Next(validMoves.Count)];
    }
}
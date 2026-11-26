public class RandomPlayer : IPlayer
{
    private readonly Random random;
    public RandomPlayer(Random random)
    {
        this.random = random;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        return validMoves[random.Next(validMoves.Count)];
    }
}
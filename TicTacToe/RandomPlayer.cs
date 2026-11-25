class RandomPlayer : IPlayer
{
    private readonly Random random;
    private readonly Mark mark;

    public RandomPlayer(Random random, Mark mark)
    {
        this.random = random;
        this.mark = mark;
    }

    public void PlayTurn(Board board)
    {
        List<int> freePositions = board.ListFreePositions();

        int index = random.Next(freePositions.Count);

        board.Place(freePositions[index], mark);
    }
}
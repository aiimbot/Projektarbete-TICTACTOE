class SmartPlayer : IPlayer
{
    private readonly Mark mark;
    private readonly Mark opponent;
    private readonly Random random;

    private readonly int[][] winningCombinations =
    {
        new[] { 1, 2, 3 },
        new[] { 4, 5, 6 },
        new[] { 7, 8, 9 },
        new[] { 1, 4, 7 },
        new[] { 2, 5, 8 },
        new[] { 3, 6, 9 },
        new[] { 1, 5, 9 },
        new[] { 3, 5, 7 }
    };

    public SmartPlayer(Random random, Mark mark)
    {
        this.random = random;
        this.mark = mark;
        opponent = mark == Mark.X ? Mark.O : Mark.X;
    }

    public int ChooseMove(Board board, List<int> validMoves)
    {
        int winningMove = FindWinningMove(board, mark, validMoves);

        if (winningMove != -1)
        {
            return winningMove;
        }

        int blockingMove = FindWinningMove(board, opponent, validMoves);

        if (blockingMove != -1)
        {
            return blockingMove;
        }

        if (validMoves.Contains(5))
        {
            return 5;
        }

        int[] corners = { 1, 3, 7, 9 };
        List<int> freeCorners = new List<int>();

        foreach (int corner in corners)
        {
            if (validMoves.Contains(corner))
            {
                freeCorners.Add(corner);
            }
        }

        if (freeCorners.Count > 0)
        {
            return freeCorners[random.Next(freeCorners.Count)];
        }
        
        return validMoves[random.Next(validMoves.Count)];
    }

    private int FindWinningMove(Board board, Mark target, List<int> validMoves)
    {
        foreach (int[] combination in winningCombinations)
        {
            int a = combination[0];
            int b = combination[1];
            int c = combination[2];

            if (board.Holds(a, target) &&
                board.Holds(b, target) &&
                validMoves.Contains(c))
            {
                return c;
            }

            if (board.Holds(a, target) &&
                board.Holds(c, target) &&
                validMoves.Contains(b))
            {
                return b;
            }

            if (board.Holds(b, target) &&
                board.Holds(c, target) &&
                validMoves.Contains(a))
            {
                return a;
            }
        }

        return -1;
    }
}
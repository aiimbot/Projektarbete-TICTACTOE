public class SmartPlayer : IPlayer
{
    private readonly Mark mark;
    private readonly Mark opponent;
    private readonly Random random;

    private readonly int[][] winningCombinations =
    {
        new[] { 0, 1, 2 },
        new[] { 3, 4, 5 },
        new[] { 6, 7, 8 },
        new[] { 0, 3, 6 },
        new[] { 1, 4, 7 },
        new[] { 2, 5, 8 },
        new[] { 0, 4, 8 },
        new[] { 2, 4, 6 }
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

        if (validMoves.Contains(4))
        {
            return 4;
        }

        int[] corners = { 0, 2, 6, 8 };
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
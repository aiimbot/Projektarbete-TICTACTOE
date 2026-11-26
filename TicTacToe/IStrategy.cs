public interface IStrategy
{
    int? FindMove(Board board, List<int> validMoves);
}
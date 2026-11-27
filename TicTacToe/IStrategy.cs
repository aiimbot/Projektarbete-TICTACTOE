public interface IStrategy
{
    // Subtypspolymorfism: gemensam signatur för alla datorstrategier
    int? FindMove(Board board, List<int> validMoves);
}
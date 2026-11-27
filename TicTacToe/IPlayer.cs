public interface IPlayer
{
    // Subtypspolymorfism: gemensam signatur för människa och dator.
    int ChooseMove(Board board, List<int> validMoves);
}
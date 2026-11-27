// Arv: ärver IsWinner och IsDraw från Ruleset
public class GravityRuleset : Ruleset
{
    public GravityRuleset(int lineLength) : base(lineLength)
    {
    }

    // Arv: skriver över det från basklassen, giltiga drag är kolumner i stället för rutor
    public override List<int> ListValidMoves(Board board)
    {
        return board.ListFreeColumns();
    }

    // Arv: skriver över, märket faller till lägsta lediga ruta
    public override void Place(Board board, int move, Mark mark)
    {
        board.Place(board.FindLowestFree(move), mark);
    }
}
public class HumanPlayer : IPlayer
{
    private readonly string name;
    private readonly Prompt prompt;

    public HumanPlayer(string name, Prompt prompt)
    {
        this.name = name;
        this.prompt = prompt;
    }

    // Subtypspolymorfism: väljer drag via inmatning från tangentbordet
    public int ChooseMove(Board board, List<int> validMoves)
    {
        string options = string.Join(", ", validMoves.Select(m => m + 1));
        string text = $"{name}, välj ({options}): ";
        int move;

        do
        {
            move = prompt.AskNumber(text, validMoves.Min() + 1, validMoves.Max() + 1) - 1;
        }
        while (!validMoves.Contains(move));

        return move;
    }
}
public class HumanPlayer : IPlayer
{
    private readonly string name;
    public HumanPlayer(string name)
    {
        this.name = name;
    }
    public int ChooseMove(Board board, List<int> validMoves)
    {
        string options = string.Join(", ", validMoves.Select(m => m + 1));

        while (true)
        {
            Console.Write($"{name}, välj ({options}): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number)
                && validMoves.Contains(number - 1))
            {
                return number - 1;
            }

            Console.WriteLine("Ogiltigt val, försök igen.");
        }
    }
}